using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql;
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
using static System.Windows.Forms.AxHost;

namespace EmployeeFormsApp
{
    public partial class EmployeesCardLook : Form
    {
        private int employeeId;
        private DbConnect _context;
        private Employee employee;

        public EmployeesCardLook(int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox17.ReadOnly = true;
            textBox16.ReadOnly = true;
            textBox18.ReadOnly = true;
            textBox21.ReadOnly = true;
            textBox22.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox19.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox20.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox15.ReadOnly = true;
            textBox15.ReadOnly = true;
            this.employeeId = employeeId;
            _context = new DbConnect();
            LoadEmployeeData();


        }

        private void LoadEmployeeData()
        {
            using (var context = new DbConnect())
            {
                employee =  _context.Employees
                .Include(e => e.PositionInfos).ThenInclude(pi => pi.Position)
                .Include(e => e.Branch)
                .Include(e => e.Department)
                .Include(e => e.Education)
                .FirstOrDefault(e => e.Id == employeeId);
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
                    
                }
                else
                {
                    MessageBox.Show("Сотрудник не найден в базе данных.");
                    this.Close();
                }


              
            }
        }

        
    }
}