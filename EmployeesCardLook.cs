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
            LoadEmployeeData();



        }

        private void LoadEmployeeData()
        {
            using (var context = new DbConnect())
            {
                var employee = context.Employees
                    
                    .Where(e => e.Id == employeeId)
                    .Select(e => new
                    {
                        e.Name,
                        e.Surname,
                        e.Patronymic,
                        e.Gender,
                        e.BirthDate,
                        e.Address,
                        PositionInfos = e.PositionInfos.Select(pi => pi.Position).ToList(),
                        e.INN,
                        e.SNILS,
                        e.PhoneNumber,
                        e.Email,
                        e.HireDate,
                        BranchName = e.Branch.Name,
                        DepartmentName = e.Department.Name,
                        DepartmentHead = e.Department.Head,
                        Positions = e.PositionInfos.Select(pi => pi.Position).Select(a => a.Name).FirstOrDefault(),
                        e.PassportSeries,
                        e.PassportNumber,
                        e.PassportIssueDate,
                        e.PassportIssueBy,
                        e.PhotoPath,
                        Salary = e.PositionInfos.Select(pi => pi.Position).Select(a => a.Salary).FirstOrDefault(),
                        EducationsLevel = e.Education.EducationLevel,
                        EducationsSpecialization = e.Education.Specialization,
                        EducationsInstitution = e.Education.Institution,
                        Date = e.Education.DateGrade,
                        
                    })
                    .FirstOrDefault();
                
                    textBox1.Text = employee.Name;
                    textBox2.Text = employee.Surname;
                    textBox3.Text = employee.Patronymic;
                    textBox4.Text = employee.Gender;
                    dateTimePicker1.Value = employee.BirthDate.Value; 
                    textBox6.Text = employee.Address;
                    textBox7.Text = string.Join(", ", employee.Positions);
                    textBox8.Text = employee.INN;
                    textBox5.Text = employee.SNILS;
                    textBox17.Text = employee.PhoneNumber;
                    textBox16.Text = employee.Email;
                    dateTimePicker5.Value = employee.HireDate; 
                    textBox18.Text = employee.BranchName;
                    textBox21.Text = employee.DepartmentName;
                    textBox22.Text = employee.DepartmentHead;
                    textBox9.Text = employee.PassportSeries;
                    textBox10.Text = employee.PassportNumber;
                    dateTimePicker2.Value = employee.PassportIssueDate.Value; 
                    textBox19.Text = employee.PassportIssueBy;
                    textBox11.Text = employee.Address;
                    textBox20.Text = string.Join(", ", employee.Salary);
                    textBox5.Text = employee.SNILS;
                    textBox13.Text = string.Join(", ", employee.EducationsLevel);
                    textBox14.Text = string.Join(", ", employee.EducationsSpecialization);
                    textBox15.Text = string.Join(", ", employee.EducationsInstitution);
                    textBox15.Text = string.Join(", ", employee.EducationsInstitution);
                    dateTimePicker4.Value =  employee.Date;
                    //pictureBox1.Image = Image.FromFile(employee.PhotoPath);
            }
        }

        
    }
}