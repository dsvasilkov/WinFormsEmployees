using System.Windows.Forms;

namespace EmployeeFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadListEmployees = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.searchInputField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посмотретьКарточкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьКарточкуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сотрудникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьКарточкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьКарточкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьКарточкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.loadListEmployees);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.searchInputField);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 703);
            this.panel1.TabIndex = 0;
            // 
            // loadListEmployees
            // 
            this.loadListEmployees.Image = ((System.Drawing.Image)(resources.GetObject("loadListEmployees.Image")));
            this.loadListEmployees.Location = new System.Drawing.Point(579, 41);
            this.loadListEmployees.Name = "loadListEmployees";
            this.loadListEmployees.Size = new System.Drawing.Size(83, 68);
            this.loadListEmployees.TabIndex = 13;
            this.loadListEmployees.UseVisualStyleBackColor = true;
            this.loadListEmployees.Click += new System.EventHandler(this.loadListEmployees_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(963, 134);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 36);
            this.button3.TabIndex = 12;
            this.button3.Text = "Обновить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // searchInputField
            // 
            this.searchInputField.Location = new System.Drawing.Point(228, 134);
            this.searchInputField.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchInputField.Name = "searchInputField";
            this.searchInputField.Size = new System.Drawing.Size(670, 31);
            this.searchInputField.TabIndex = 11;
            this.searchInputField.TextChanged += new System.EventHandler(this.searchEmployee);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 131);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Быстрый поиск ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 175);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 373);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.showEmployeeCard);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(294, 48);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(278, 55);
            this.button2.TabIndex = 5;
            this.button2.Text = "Удалить сотрудника ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.deleteEmployee);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(9, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(278, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить сотрудника ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addEmployee);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сотрудникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 42);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.посмотретьКарточкуToolStripMenuItem,
            this.изменитьКарточкуToolStripMenuItem1});
            this.сотрудникиToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(166, 36);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            // 
            // посмотретьКарточкуToolStripMenuItem
            // 
            this.посмотретьКарточкуToolStripMenuItem.Name = "посмотретьКарточкуToolStripMenuItem";
            this.посмотретьКарточкуToolStripMenuItem.Size = new System.Drawing.Size(393, 44);
            this.посмотретьКарточкуToolStripMenuItem.Text = "Посмотреть карточку ";
            this.посмотретьКарточкуToolStripMenuItem.Click += new System.EventHandler(this.showEmployeeCard);
            // 
            // изменитьКарточкуToolStripMenuItem1
            // 
            this.изменитьКарточкуToolStripMenuItem1.Name = "изменитьКарточкуToolStripMenuItem1";
            this.изменитьКарточкуToolStripMenuItem1.Size = new System.Drawing.Size(393, 44);
            this.изменитьКарточкуToolStripMenuItem1.Text = "Изменить карточку";
            this.изменитьКарточкуToolStripMenuItem1.Click += new System.EventHandler(this.changeEmployeeCard);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сотрудникToolStripMenuItem,
            this.открытьКарточкуToolStripMenuItem,
            this.изменитьКарточкуToolStripMenuItem,
            this.удалитьКарточкуToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(312, 156);
            // 
            // сотрудникToolStripMenuItem
            // 
            this.сотрудникToolStripMenuItem.Name = "сотрудникToolStripMenuItem";
            this.сотрудникToolStripMenuItem.Size = new System.Drawing.Size(311, 38);
            this.сотрудникToolStripMenuItem.Text = "Сотрудник";
            // 
            // открытьКарточкуToolStripMenuItem
            // 
            this.открытьКарточкуToolStripMenuItem.Name = "открытьКарточкуToolStripMenuItem";
            this.открытьКарточкуToolStripMenuItem.Size = new System.Drawing.Size(311, 38);
            this.открытьКарточкуToolStripMenuItem.Text = "Открыть карточку";
            // 
            // изменитьКарточкуToolStripMenuItem
            // 
            this.изменитьКарточкуToolStripMenuItem.Name = "изменитьКарточкуToolStripMenuItem";
            this.изменитьКарточкуToolStripMenuItem.Size = new System.Drawing.Size(311, 38);
            this.изменитьКарточкуToolStripMenuItem.Text = "Изменить карточку ";
            // 
            // удалитьКарточкуToolStripMenuItem
            // 
            this.удалитьКарточкуToolStripMenuItem.Name = "удалитьКарточкуToolStripMenuItem";
            this.удалитьКарточкуToolStripMenuItem.Size = new System.Drawing.Size(311, 38);
            this.удалитьКарточкуToolStripMenuItem.Text = "Удалить карточку ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Клиентское приложение для учёта новых сотрудников";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сотрудникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьКарточкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьКарточкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьКарточкуToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem посмотретьКарточкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьКарточкуToolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchInputField;
        private Button button3;
        private Button loadListEmployees;
    }
}

