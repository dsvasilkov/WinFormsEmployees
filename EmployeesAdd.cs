using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public EmployeesAdd()
        {
            InitializeComponent();
            _context = new DbConnect();
        }
        private async void addEmployee(object sender, EventArgs e)
        {
            string name = Name.Text;
            string surname = Surname.Text;
            string patronymic = Patronymic.Text;
            DateTime hireDate = DateTime.Parse(HireDate.Text);
            Employee employee = new Employee() { Name = name, Surname = surname, Patronymic = patronymic,
                HireDate = hireDate};

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(employee, null, null);
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            if (isValid)
            {
                try
                {
                    await _context.Database.ExecuteSqlInterpolatedAsync(
                        $"CALL AddEmployee({name}, {surname}, {patronymic}, {hireDate})");
                    EmployeeAdded?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Данные успешно добавлены");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка добавления данных: {ex.Message}");
                }
            }
            else MessageBox.Show(String.Join("\n", validationResults.Select(res => res.ErrorMessage)));

          
        }

    }
}