using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeFormsApp
{
    public partial class MainForm : Form
    {
        private string connectionString = "Host=localhost;Database=emloyees;Username=postgres;Password=admin";
        private int selectedEmployeeId;
        public MainForm()
        {   
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // WaitForTable();
            LoadEmployees();
        }

       private void LoadEmployees()
       {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                
                using (var command = new NpgsqlCommand("SELECT * FROM GetEmployees()", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }

        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.ForeColor = Color.Black; 
        }
        

        private void changeEmployeeCard(object sender, EventArgs e)
        {
            EmployeesCardChange employeesCardChange = new EmployeesCardChange();
            employeesCardChange.Show();
        }
        private void addEmployee(object sender, EventArgs e)
        {
            EmployeesAdd employeesAdd = new EmployeesAdd();
            employeesAdd.Show();
        }

        private void showEmployeeCard(object sender, EventArgs e)
        {
            EmployeesCardLook employeesCardLook = new EmployeesCardLook(selectedEmployeeId);
            employeesCardLook.Show();
        }

        private void deleteEmployee(object sender, EventArgs e)
        {

        }

        private void searchEmployee(object sender, EventArgs e)
        {
            string searchValue = searchInputField.Text;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM SearchEmployee(@search)", connection))
                {
                    command.Parameters.AddWithValue("@search", searchValue);
                    using (var reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }

        }
        private void da()
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            using (var contex = new DbConnect())
            {
                var employee = new Employee();

                    selectedEmployeeId = employee.Id;
                
            }
                
                
            
        }
    }
}
