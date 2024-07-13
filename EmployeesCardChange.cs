using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace EmployeeFormsApp
{

    public partial class EmployeesCardChange : Form
    {
        private int employeeId;
        private DbConnect _context;
        private Employee employee;
        public event EventHandler EmployeeChanged;

        public EmployeesCardChange(int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            _context = new DbConnect();

            this.Load += CardChangeForm_Load;
            readOnlyControl(null, null);
        }
        private async void CardChangeForm_Load(object sender, EventArgs e) => await LoadEmployeeData();

        private async Task LoadComboBoxData()
        {
            Position.Items.AddRange(_context.Positions.Select(p => new ComboBoxItem(p.Name, p.Id)).ToArray());
            DepartmentName.Items.AddRange(_context.Departments.Select(d => new ComboBoxItem(d.Name, d.Id)).ToArray());
            BranchName.Items.AddRange(_context.Branches.Select(b => new ComboBoxItem(b.Name, b.Id)).ToArray());
        }

        private async Task LoadEmployeeData()
        {
            await LoadComboBoxData();
           
            employee = await _context.Employees
                .Include(e => e.PositionInfos).ThenInclude(pi => pi.Position)
                .Include(e => e.Branch)
                .Include(e => e.Department)
                .Include(e => e.Education)
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            
            if (employee != null)
            {

                var position = employee.PositionInfos.LastOrDefault()?.Position;
                textBox1.Text = employee.Name;
                textBox2.Text = employee.Surname;
                textBox3.Text = employee.Patronymic;
                Gender.Text = employee.Gender;
                dateTimePicker1.Value = employee.BirthDate == null ? DateTime.Now : employee.BirthDate.Value;
                textBox6.Text = employee.Address;
                Position.Text = position?.Name;
                INN.Text = employee.INN;
                SNILS.Text = employee.SNILS;
                PhoneNumber.Text = employee.PhoneNumber;
                Email.Text = employee.Email;
                HireDate.Value = employee.HireDate;
                BranchName.Text = employee.Branch?.Name;
                DepartmentName.Text = employee.Department?.Name;
                DepartmentHead.Text = employee.Department?.Head;
                PassportSerie.Text = employee.PassportSeries;
                PassportNumber.Text = employee.PassportNumber;
                registrationAddress.Text = employee.PlaceOfReg;
                dateTimePicker2.Value = employee.PassportIssueDate == null ? DateTime.Now : employee.PassportIssueDate.Value;
                textBox19.Text = employee.PassportIssueBy;
                Salary.Text = position?.Salary.ToString();
                textBox13.Text = employee.Education?.EducationLevel;
                textBox14.Text = employee.Education?.Specialization;
                textBox15.Text = employee.Education?.Institution;
                dateTimePicker4.Value = employee.Education?.DateGrade == null ? DateTime.Now : employee.Education.DateGrade;
                /*try
                {
                    pictureBox1.Image = Image.FromFile(employee.PhotoPath);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки фото");
                } */
            }
            else
            {
                MessageBox.Show("Сотрудник не найден в базе данных.");
                this.Close();
            }
            
        }

        
        
        private void textBox1_TextChanged(object sender, EventArgs e) => employee.Name = textBox1.Text;
    

        private async void saveBasicInfo(object sender, EventArgs e)
        {
            employee.Name = textBox1.Text;
            employee.Surname = textBox2.Text;
            employee.Patronymic = textBox3.Text.Length == 0 ? null : textBox3.Text;
            employee.Gender = Gender.Text;
            employee.BirthDate = dateTimePicker1.Value;
            employee.Address = textBox6.Text;
            employee.Email = Email.Text.Length == 0 ? null : Email.Text;
            employee.PhoneNumber = PhoneNumber.Text;
            employee.SNILS = SNILS.Text;
            employee.INN = INN.Text;


            var selectedPos = (ComboBoxItem)Position?.SelectedItem;
            int positionId = 0, departmentId = 0, branchId = 0;
            string positionText = "", departmentText = "", branchText = "";
            if (selectedPos != null)
            {
                positionId = selectedPos.Id;
                positionText = selectedPos.Text;
            }
            var selectedDepartment = (ComboBoxItem)DepartmentName?.SelectedItem;
            if (selectedDepartment != null)
            {
                departmentId = selectedDepartment.Id;
                departmentText = selectedDepartment.Text;
            }
            var selectedBranch = (ComboBoxItem)BranchName?.SelectedItem;
            if (selectedBranch != null)
            {
                branchId = selectedBranch.Id;
                branchText = selectedBranch.Text;
            }

            if (positionId != 0 && employee.PositionInfos.LastOrDefault()?.Position.Name != positionText)
            { 
                employee.PositionInfos.Add(new PositionInfo { Date = new DateTime(), PositionId = positionId,
                    Employee = employee, Position  = _context.Positions.FirstOrDefault(b => b.Id == positionId)
                });
                if (employee.PositionInfos.LastOrDefault().Position.Salary != int.Parse(Salary.Text))
                    employee.PositionInfos.LastOrDefault().Position.Salary = int.Parse(Salary.Text);
            }
            employee.HireDate = HireDate.Value;

            if (branchId != 0 && employee.Branch?.Name != branchText)
                employee.Branch = _context.Branches.FirstOrDefault(b => b.Id == branchId);

            if (departmentId != 0 && employee.Department?.Name != departmentText)
                employee.Department = _context.Departments.FirstOrDefault(d => d.Id == departmentId);

            await ValidateAndSaveData();

        }
        
        private async Task ValidateAndSaveData()
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(employee, null, null);
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            if (isValid)
            {
                try
                {
                    await _context.SaveChangesAsync();
                    EmployeeChanged?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Данные успешно обновлены");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Ошибка сохранения данных: {ex.Message}");
                }
            }
            else MessageBox.Show(String.Join("\n", validationResults.Select(res => res.ErrorMessage)));
        }
        
        
        private async void savePassportData(object sender, EventArgs e)
        {
            employee.PassportIssueDate = dateTimePicker2.Value;
            employee.PassportIssueBy = textBox19.Text;
            employee.Address = registrationAddress.Text;
            employee.PassportSeries = PassportSerie.Text;
            employee.PhoneNumber = PassportNumber.Text;

            await ValidateAndSaveData();
        }

        private async void SaveEducationInfo(object sender, EventArgs e)
        {
            if (employee.Education == null)
            {
                employee.Education = new Education()
                {
                    EducationLevel = textBox13.Text,
                    Specialization = textBox14.Text,
                    Institution = textBox15.Text,
                    DateGrade = dateTimePicker4.Value
                };
            }
            else
            {
                employee.Education.EducationLevel = textBox13.Text;
                employee.Education.Specialization = textBox14.Text;
                employee.Education.Institution = textBox15.Text;
                employee.Education.DateGrade = dateTimePicker4.Value;
            }
            await ValidateAndSaveData();
        }

        private void readOnlyControl(object sender, EventArgs e)
        {
            if (Position.SelectedIndex != -1)
                Salary.ReadOnly = false;
            else
                Salary.ReadOnly = true;
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Id { get; set; }

        public ComboBoxItem(string text, int id)
        {
            Text = text;
            Id = id;
        }

        public override string ToString() => Text;

    }
}
