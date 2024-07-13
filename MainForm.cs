using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;
using Ude;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace EmployeeFormsApp
{
    public partial class MainForm : Form
    {
        private readonly DbConnect _context;
        private int selectedEmployeeId;
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _context = new DbConnect();
            this.Load += MainForm_Load;
        }
        private async void MainForm_Load(object sender, EventArgs e) => await LoadEmployees();

        private async Task LoadEmployees()
        {
            using (var context = new DbConnect())
            {
                var employees = await context.TableEmployee.FromSqlInterpolated
                ($"SELECT * FROM GetEmployees()").ToListAsync();

                var Employees = employees.Select(el =>
                    new
                    {
                        Id = el.Id,
                        Имя = el.Name,
                        Фамилия = el.Surname,
                        Отчество = el.Patronymic,
                        Дата_трудоустройства = el.HireDate
                    }).ToList();
                dataGridView1.DataSource = Employees;
                dataGridView1.Columns["Id"].Visible = false;
            }
            selectFirstRow();
        }

        private async void addEmployee(object sender, EventArgs e)
        {
            EmployeesAdd employeesAdd = new EmployeesAdd();

            var tcs = new TaskCompletionSource<bool>();
            employeesAdd.EmployeeAdded += (s, args) => tcs.SetResult(true);
            employeesAdd.Show();
            await tcs.Task;

            await LoadEmployees();
        }

        private async void deleteEmployee(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                if (row.Cells["Id"].Value != null)
                    selectedIds.Add((int)row.Cells["Id"].Value);

            await _context.Database.ExecuteSqlInterpolatedAsync
                ($"CALL DeleteEmployeesByIds({selectedIds.ToArray()})");
            await LoadEmployees();
        }
        private void dataGridView1_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e) => e.CellStyle.ForeColor = Color.Black;

        private async void changeEmployeeCard(object sender, EventArgs e)
        {
            EmployeesCardChange employeesCardChange = new EmployeesCardChange(selectedEmployeeId);
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            void Handler(object s, EventArgs args)
            {
                tcs.TrySetResult(true);
            }

            employeesCardChange.EmployeeChanged += Handler;

            employeesCardChange.Show();

            while (await tcs.Task)
            {
                await LoadEmployees();
                tcs = new TaskCompletionSource<bool>();
                employeesCardChange.EmployeeChanged += Handler;
            }

            employeesCardChange.EmployeeChanged -= Handler;

        }

        private void selectFirstRow()
        {
            if (dataGridView1.Rows.Count > 0)
                selectedEmployeeId = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
        }

        private void showEmployeeCard(object sender, EventArgs e)
        {
            EmployeesCardLook employeesCardLook = new EmployeesCardLook(selectedEmployeeId);
            employeesCardLook.Show();
        }



        private async void searchEmployee(object sender, EventArgs e)
        {
            string searchValue = searchInputField.Text;
            var employees = await _context.TableEmployee.FromSqlInterpolated
               ($"SELECT * FROM SearchEmployee({searchValue})").ToListAsync();
            var employeesWithoutId = employees.Select(el =>
            new
            {
                Имя = el.Name,
                Фамилия = el.Surname,
                Отчество = el.Patronymic,
                Дата_трудоустройства = el.HireDate
            }).ToList();

            dataGridView1.DataSource = employeesWithoutId;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                selectedEmployeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await LoadEmployees();
            MessageBox.Show("Данные успешно обновлены");
        }



        private async void loadListEmployees_Click(object sender, EventArgs e)
        {
            string projectPath = (new FileInfo(AppDomain.CurrentDomain.BaseDirectory)).Directory.Parent.Parent.FullName;
            string xsdFilePath = Path.Combine(projectPath, "files/employees.xsd");
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(projectPath, "files"),
                Filter = "XML files (*.xml)|*.xml",
                Title = "Select an XML file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string xmlFilePath = openFileDialog.FileName;

                try
                {
                    var messages = await AddEmployeesFromXmlAsync(xmlFilePath, xsdFilePath);
                    await LoadEmployees();
                    MessageBox.Show((messages.addedEmployees != "" ?
                        ("Следующие сотрудники успешно добавлены: " + messages.addedEmployees) + " " : "") +
                        (messages.errors != "" ? messages.errors : ""));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении сотрудников: {ex.Message}");
                }
            }
        }

        public async Task<(string errors, string addedEmployees)> AddEmployeesFromXmlAsync(string xmlFilePath, string xsdFilePath)
        {
            if (!File.Exists(xmlFilePath))
            {
                throw new InvalidDataException("XML файл не найден");
            }

            if (!File.Exists(xsdFilePath))
            {
                throw new InvalidDataException("XSD файл не найден");
            }
            ConvertXmlToUtf8(xmlFilePath, xmlFilePath);
            XDocument doc = XDocument.Load(xmlFilePath);
            if (!ValidateXml(doc, xsdFilePath))
            {
                throw new InvalidDataException("XML файл не соответствует XSD схеме");
            }

            List<Employee> newEmployees = new List<Employee>();
            StringBuilder errors = new StringBuilder("Следующие сотрудники уже существуют: ");
            StringBuilder addedEmployees = new StringBuilder();

            foreach (XElement employeeElement in doc.Descendants("Employee"))
            {
                var name = employeeElement.Element("Name")?.Value;
                var surname = employeeElement.Element("Surname")?.Value;

                if (name == null || surname == null)
                    throw new InvalidDataException("Имя и фамилия обязательны для каждого сотрудника");

                var patronymic = employeeElement.Element("Patronymic")?.Value;
                var hireDate = DateTime.Parse(employeeElement.Element("HireDate")?.Value ??
                        DateTime.Now.ToString());

                var existingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Name == name &&
                    e.Surname == surname && e.Patronymic == patronymic);

                if (existingEmployee == default)
                {
                    int branchId = int.Parse(employeeElement.Element("BranchId")?.Value ?? "0");
                    Branch branch = await _context.Branches.FindAsync(branchId);
                    int departmentId = int.Parse(employeeElement.Element("DepartmentId")?
                        .Value ?? "0");
                    Department department = await _context.Departments.FindAsync(departmentId);
                    var birthDate = employeeElement.Element("BirthDate")?.Value;
                    var passportIssueDate = employeeElement.Element("PassportIssueDate")?.Value;

                    if ((branch != null || branchId == 0) && (department != null ||
                        departmentId == 0))
                    {
                        Employee newEmployee = new Employee
                        {
                            Name = name,
                            Surname = surname,
                            Patronymic = patronymic,
                            Gender = employeeElement.Element("Gender")?.Value,
                            BirthDate = !string.IsNullOrEmpty(birthDate) ?
                                DateTime.Parse(birthDate) : (DateTime?)null,
                            Address = employeeElement.Element("Address")?.Value,
                            PhoneNumber = employeeElement.Element("PhoneNumber")?.Value,
                            Email = employeeElement.Element("Email")?.Value,
                            HireDate = DateTime.Parse(employeeElement.Element("HireDate")?
                            .Value ?? DateTime.Now.ToString()),
                            INN = employeeElement.Element("INN")?.Value,
                            SNILS = employeeElement.Element("SNILS")?.Value,
                            PassportSeries = employeeElement.Element("PassportSeries")?.Value,
                            PassportNumber = employeeElement.Element("PassportNumber")?.Value,
                            PassportIssueDate = !string.IsNullOrEmpty(passportIssueDate) ?
                                DateTime.Parse(passportIssueDate) : (DateTime?)null,
                            PassportIssueBy = employeeElement.Element("PassportIssueBy")?.Value,
                            PlaceOfReg = employeeElement.Element("PlaceOfReg")?.Value,
                            PhotoPath = employeeElement.Element("PhotoPath")?.Value,
                            BranchId = branchId == 0 ? null : (int?)branchId,
                            DepartmentId = departmentId == 0 ? null : (int?)departmentId,
                        };

                        newEmployees.Add(newEmployee);
                    }
                }
                else
                    errors.Append($"{name} {surname} {patronymic}, ");
            }
            await _context.Employees.AddRangeAsync(newEmployees);
            await _context.SaveChangesAsync();

            foreach (var e in newEmployees)
                addedEmployees.Append($"{e.Name} {e.Surname} {e.Patronymic}, ");

            (string errors, string addedEmployees) pair = (deleteComma(errors.ToString()),
                deleteComma(addedEmployees.ToString()));
            return pair;

        }

        private string deleteComma(string str)
        {
            var commaPos = str.LastIndexOf(',');
            if (commaPos != -1)
            {
                return (str.Substring(0, commaPos) + "!");
            }
            return "";
        }

        private bool ValidateXml(XDocument xmlDocument, string xsdFilePath)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", xsdFilePath);

            bool isValid = true;
            xmlDocument.Validate(schemas, (sender, e) =>
            {
                isValid = false;
                MessageBox.Show($"Validation Error: {e.Message}");
            });

            return isValid;
        }
        public Encoding DetectEncodingWithUde(string xmlFilePath)
        {
            using (var fileStream = File.OpenRead(xmlFilePath))
            {
                CharsetDetector detector = new CharsetDetector();
                detector.Feed(fileStream);
                detector.DataEnd();

                if (detector.Charset != null)
                {
                    return Encoding.GetEncoding(detector.Charset);
                }
                else
                {
                    throw new Exception("Не удалось определить кодировку файла.");
                }
            }
        }

        public string DetectXmlDeclaredEncoding(string xmlContent)
        {
            var match = Regex.Match(xmlContent, @"<\?xml\s+version=""1\.0""\s+encoding=""([^\s""]+)""\s*\?>");
            if (match.Success)
                return match.Groups[1].Value.ToLower();
            return "utf-8";
        }

        public void ConvertXmlToUtf8(string xmlFilePath, string outputFilePath)
        {
            Encoding currentEncoding = DetectEncodingWithUde(xmlFilePath);

            string xmlContent;
            using (var reader = new StreamReader(xmlFilePath, currentEncoding))
                xmlContent = reader.ReadToEnd();
            

            string declaredEncoding = DetectXmlDeclaredEncoding(xmlContent);

            if (currentEncoding.WebName.ToLower() == "utf-8" && declaredEncoding == "utf-8")     
                return;

            xmlContent = Regex.Replace(xmlContent, @"<\?xml\s+version=""1\.0""\s+encoding=""[^\s""]+""\s*\?>",
                @"<?xml version=""1.0"" encoding=""utf-8""?>");

            using (var writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
                writer.Write(xmlContent);
        }
    }
}
