using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeFormsApp
{
    public partial class EmployeesAdd : Form
    {
        private readonly DbConnect _context;
        public event EventHandler EmployeeAdded;
        public EmployeesAdd(DbConnect context)
        {
            InitializeComponent();
            _context=context;
        }
        private async void addEmployee(object sender, EventArgs e)
        {
            string name = Name.Text;
            string surname = Surname.Text;
            string patronymic = Patronymic.Text;
            DateTime hireDate = DateTime.Parse(HireDate.Text);
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"CALL AddEmployee({name}, {surname}, {patronymic}, {hireDate})");
            EmployeeAdded?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
