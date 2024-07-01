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
    public partial class EmployeesCardChange : Form
    {
        public EmployeesCardChange()
        {
            InitializeComponent();
        }

        public EmployeesCardChange(MainForm mainForm)
        {
            InitializeComponent();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void saveChangesBasicInfo(object sender, EventArgs e)
        {

        }
        private void saveChangesPassport(object sender, EventArgs e)
        {

        }
        private void saveChangesEducation(object sender, EventArgs e)
        {

        }
    }
}
