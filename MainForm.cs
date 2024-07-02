﻿using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeFormsApp
{
    public partial class MainForm : Form
    {
        private readonly DbConnect _context;
        private string connectionString = "Host=localhost;Database=employees;Username=postgres;Password=root";
        private int selectedEmployeeId;
        public MainForm(DbConnect context)
        {   
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _context = context;
            this.Load += MainForm_Load;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadEmployees();
        }

        private async Task LoadEmployees()
        {
            var employees = await _context.TableEmployee.FromSqlInterpolated
                ($"SELECT * FROM GetEmployees()").ToListAsync();
                    
            var employeesWithoutId = employees.Select(el =>
                new { Id = el.Id, Имя = el.Name, Фамилия = el.Surname, Отчество = el.Patronymic, Дата_трудоустройства = el.HireDate }).ToList();
            dataGridView1.DataSource = employeesWithoutId;
            dataGridView1.Columns["Id"].Visible = false;

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
        private async void addEmployee(object sender, EventArgs e)
        {
            EmployeesAdd employeesAdd = new EmployeesAdd(_context);
            
            var tcs = new TaskCompletionSource<bool>();
            employeesAdd.EmployeeAdded += (s, args) => tcs.SetResult(true);
            employeesAdd.Show();
            await tcs.Task;
            
            await LoadEmployees();
        }

        private void showEmployeeCard(object sender, EventArgs e)
        {
            EmployeesCardLook employeesCardLook = new EmployeesCardLook(selectedEmployeeId);
            employeesCardLook.Show();
        }

        private async void deleteEmployee(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells["Id"].Value != null)
                {
                    selectedIds.Add((int)row.Cells["Id"].Value);
                }
            }
          
            await _context.Database.ExecuteSqlInterpolatedAsync
                ($"CALL DeleteEmployeesByIds({selectedIds.ToArray()})");
            await LoadEmployees();

        }
    

        private async void searchEmployee(object sender, EventArgs e)
        {
            string searchValue = searchInputField.Text;
            var employees = await _context.TableEmployee.FromSqlInterpolated
               ($"SELECT * FROM SearchEmployee({searchValue})").ToListAsync();
            var employeesWithoutId = employees.Select(el =>
            new { Имя = el.Name, Фамилия = el.Surname, Отчество = el.Patronymic,
                Дата_трудоустройства = el.HireDate }).ToList();

            dataGridView1.DataSource = employeesWithoutId;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                selectedEmployeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
        }
    }
}
