using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    private async void CardChangeForm_Load(object sender, EventArgs e)
    {
        await LoadEmployeeData();
    }

    private async Task LoadEmployeeData()
        {
           
            employee = await _context.Employees
                .Include(e => e.PositionInfos).ThenInclude(pi => pi.Position)
                .Include(e => e.Branch)
                .Include(e => e.Department)
                .Include(e => e.Education)
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            
            if (employee != null)
            {

                textBox1.Text = employee.Name;
                textBox2.Text = employee.Surname;
                textBox3.Text = employee.Patronymic;
                textBox4.Text = employee.Gender;
                dateTimePicker1.Value = employee.BirthDate == null ? DateTime.Now : employee.BirthDate.Value;
                textBox6.Text = employee.Address;
                textBox7.Text = string.Join(", ", employee.PositionInfos.Select(pi => pi.Position.Name));
                textBox8.Text = employee.INN;
                textBox5.Text = employee.SNILS;
                textBox17.Text = employee.PhoneNumber;
                textBox16.Text = employee.Email;
                dateTimePicker5.Value = employee.HireDate;
                textBox18.Text = employee.Branch?.Name;
                textBox21.Text = employee.Department?.Name;
                textBox22.Text = employee.Department?.Head;
                textBox9.Text = employee.PassportSeries;
                textBox10.Text = employee.PassportNumber;
                dateTimePicker2.Value = employee.PassportIssueDate == null ? DateTime.Now : employee.PassportIssueDate.Value;
                textBox19.Text = employee.PassportIssueBy;
                textBox20.Text = employee.PositionInfos.Select(pi => pi.Position.Salary).FirstOrDefault().ToString();
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

        private async Task SaveEmployeeChanges()
        {
            employee.Name = textBox1.Text;
            employee.Surname = textBox2.Text;
            employee.Patronymic = textBox3.Text;
            employee.Gender = textBox4.Text;
            employee.BirthDate = dateTimePicker1.Value;
            employee.Address = textBox6.Text;
            if (employee.PositionInfos != null)
            {
                var posInfo = new PositionInfo()
                {
                    Position = new Position()
                    {
                        Name = textBox7.Text,
                        Salary = int.Parse(textBox20.Text)

                    }
                };

            }
            else
            {
                employee.PositionInfos.First().Position.Name = textBox7.Text;
                employee.PositionInfos.First().Position.Salary = int.Parse(textBox20.Text);

            }
            
            employee.INN = textBox8.Text;
            employee.SNILS = textBox5.Text;
            
            employee.PhoneNumber = textBox17.Text;
            employee.Email = textBox16.Text;
            employee.HireDate = dateTimePicker5.Value;
            if (employee.Branch == null)
            {
                employee.Branch = new Branch()
                {
                    Name = textBox13.Text,

                    Location = "ad"
                };
                
            }
            else
            {
                employee.Branch.Name = textBox13.Text;
            }
            if (employee.Department == null)
            {
                employee.Department = new Department()
                {
                    Name = textBox21.Text,
                    Head = textBox22.Text
                };
               
            }
            else
            {
                employee.Department.Name = textBox21.Text;
                employee.Department.Head = textBox22.Text;
            }
            
            
            employee.PassportSeries = textBox9.Text;
            employee.PassportNumber = textBox10.Text;
            employee.PassportIssueDate = dateTimePicker2.Value;
            employee.PassportIssueBy = textBox19.Text;
            employee.Address = textBox11.Text;
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
            
            await _context.SaveChangesAsync();
            MessageBox.Show("Данные успешно обновлены");
            EmployeeChanged?.Invoke(this, EventArgs.Empty);

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            employee.Name = textBox1.Text;
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            await SaveEmployeeChanges();
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            await SaveEmployeeChanges();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await SaveEmployeeChanges();
        }

        
    }
}
