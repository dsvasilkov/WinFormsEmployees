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

namespace EmployeeFormsApp
{
    public partial class EmployeesCardLook : Form
    {
        private int employeeId;

        public EmployeesCardLook(int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
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
                        //PositionInfos = e.PositionInfos.Select(pi => pi.Name).ToList(),
                        e.INN,
                        e.SNILS,
                        e.PhoneNumber,
                        e.Email,
                        e.HireDate,
                        BranchName = e.Branch.Name,
                        DepartmentName = e.Department.Name,
                        DepartmentHead = e.Department.Head,
                        e.PassportSeries,
                        e.PassportNumber,
                        e.PassportIssueDate,
                        e.PassportIssueBy
                    })
                    .FirstOrDefault();
                if (employee != null)
                {
                    textBox1.Text = employee.Name;
                    textBox2.Text = employee.Surname;
                    textBox3.Text = employee.Patronymic;
                    textBox4.Text = employee.Gender;
                    dateTimePicker1.Value = employee.BirthDate != null ? employee.BirthDate : DateTime.Now; 
                    textBox6.Text = employee.Address;
                    //textBox7.Text = string.Join(", ", employee.PositionInfos);
                    textBox8.Text = employee.INN;
                    textBox5.Text = employee.SNILS;
                    textBox17.Text = employee.PhoneNumber;
                    textBox16.Text = employee.Email;
                    dateTimePicker5.Value = employee.HireDate != null ? employee.HireDate : DateTime.Now; 
                    textBox18.Text = employee.BranchName;
                    textBox21.Text = employee.DepartmentName;
                    textBox22.Text = employee.DepartmentHead;
                    textBox9.Text = employee.PassportSeries;
                    textBox10.Text = employee.PassportNumber;
                    dateTimePicker2.Value = employee.PassportIssueDate != null ? employee.PassportIssueDate : DateTime.Now; 
                    textBox19.Text = employee.PassportIssueBy;
                    textBox11.Text = employee.Address;
                }
            }
        }
    }
}
//var data = context.Employees
//                    .Where(e => e.Id == employeeId)
//.Select(e => new
//                    {
//    textBox1 = employee.Name,
//                        textBox2 = employee.Surname,
//                        textBox3 = employee.Patronymic,
//                        textBox4 = employee.Gender,
//                        dateTimePicker1 = employee.BirthDate,
//                        textBox6 = employee.Address,
//                        textBox7 = employee.PositionInfos,
//    textBox8 = employee.INN,
//                        textBox5 = employee.SNILS,
//                        textBox17 = employee.PhoneNumber,
//                        textBox16 = employee.Email,
//                        dateTimePicker5 = employee.HireDate,
//                        textBox18 = employee.Branch.Name,
//                        textBox21 = employee.Department.Name,
//                        textBox22 = employee.Department.Head,
//                        textBox20 = employee.PositionInfos,
//                        textBox9 = employee.PassportSeries,
//                        textBox10 = employee.PassportNumber,
//                        dateTimePicker2 = employee.PassportIssueDate,
//                        textBox19 = employee.PassportIssueBy,
//                        textBox11 = employee.Address
//                    }).ToList();