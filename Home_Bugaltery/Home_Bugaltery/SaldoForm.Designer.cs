namespace Home_Bugaltery
{
    partial class SaldoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRevenues = new System.Windows.Forms.TextBox();
            this.textBoxExpenses = new System.Windows.Forms.TextBox();
            this.dataGridViewSaldo = new System.Windows.Forms.DataGridView();
            this.btnClouse = new System.Windows.Forms.Button();
            this.btnAply = new System.Windows.Forms.Button();
            this.panelDate = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFor = new System.Windows.Forms.DateTimePicker();
            this.checkBoxDate = new System.Windows.Forms.CheckBox();
            this.textBoxSaldo = new System.Windows.Forms.TextBox();
            this.UsersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expenses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revenues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaldo)).BeginInit();
            this.panelDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxSaldo);
            this.panel1.Controls.Add(this.textBoxRevenues);
            this.panel1.Controls.Add(this.textBoxExpenses);
            this.panel1.Location = new System.Drawing.Point(44, 528);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 51);
            this.panel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(61, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Загальна сума :";
            // 
            // textBoxRevenues
            // 
            this.textBoxRevenues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRevenues.Location = new System.Drawing.Point(353, 9);
            this.textBoxRevenues.Multiline = true;
            this.textBoxRevenues.Name = "textBoxRevenues";
            this.textBoxRevenues.Size = new System.Drawing.Size(106, 29);
            this.textBoxRevenues.TabIndex = 5;
            // 
            // textBoxExpenses
            // 
            this.textBoxExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxExpenses.Location = new System.Drawing.Point(240, 9);
            this.textBoxExpenses.Multiline = true;
            this.textBoxExpenses.Name = "textBoxExpenses";
            this.textBoxExpenses.Size = new System.Drawing.Size(104, 29);
            this.textBoxExpenses.TabIndex = 5;
            // 
            // dataGridViewSaldo
            // 
            this.dataGridViewSaldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSaldo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsersName,
            this.Expenses,
            this.Revenues,
            this.Saldo});
            this.dataGridViewSaldo.Location = new System.Drawing.Point(44, 209);
            this.dataGridViewSaldo.Name = "dataGridViewSaldo";
            this.dataGridViewSaldo.Size = new System.Drawing.Size(585, 313);
            this.dataGridViewSaldo.TabIndex = 12;
            // 
            // btnClouse
            // 
            this.btnClouse.Location = new System.Drawing.Point(295, 596);
            this.btnClouse.Name = "btnClouse";
            this.btnClouse.Size = new System.Drawing.Size(75, 23);
            this.btnClouse.TabIndex = 11;
            this.btnClouse.Text = "Закрити";
            this.btnClouse.UseVisualStyleBackColor = true;
            this.btnClouse.Click += new System.EventHandler(this.btnClouse_Click);
            // 
            // btnAply
            // 
            this.btnAply.Location = new System.Drawing.Point(146, 168);
            this.btnAply.Name = "btnAply";
            this.btnAply.Size = new System.Drawing.Size(389, 23);
            this.btnAply.TabIndex = 10;
            this.btnAply.Text = "Вивести за перiод";
            this.btnAply.UseVisualStyleBackColor = true;
            this.btnAply.Click += new System.EventHandler(this.btnAply_Click);
            // 
            // panelDate
            // 
            this.panelDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDate.Controls.Add(this.label2);
            this.panelDate.Controls.Add(this.label1);
            this.panelDate.Controls.Add(this.dateTimeTo);
            this.panelDate.Controls.Add(this.dateTimeFor);
            this.panelDate.Location = new System.Drawing.Point(233, 36);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(200, 115);
            this.panelDate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "дата до :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "дата вiд :";
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTo.Location = new System.Drawing.Point(29, 80);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(117, 20);
            this.dateTimeTo.TabIndex = 0;
            // 
            // dateTimeFor
            // 
            this.dateTimeFor.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFor.Location = new System.Drawing.Point(29, 29);
            this.dateTimeFor.Name = "dateTimeFor";
            this.dateTimeFor.Size = new System.Drawing.Size(117, 20);
            this.dateTimeFor.TabIndex = 0;
            // 
            // checkBoxDate
            // 
            this.checkBoxDate.AutoSize = true;
            this.checkBoxDate.Location = new System.Drawing.Point(233, 12);
            this.checkBoxDate.Name = "checkBoxDate";
            this.checkBoxDate.Size = new System.Drawing.Size(60, 17);
            this.checkBoxDate.TabIndex = 8;
            this.checkBoxDate.Text = "Перiод";
            this.checkBoxDate.UseVisualStyleBackColor = true;
            this.checkBoxDate.CheckedChanged += new System.EventHandler(this.checkBoxDate_CheckedChanged);
            // 
            // textBoxSaldo
            // 
            this.textBoxSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSaldo.Location = new System.Drawing.Point(468, 9);
            this.textBoxSaldo.Multiline = true;
            this.textBoxSaldo.Name = "textBoxSaldo";
            this.textBoxSaldo.Size = new System.Drawing.Size(110, 29);
            this.textBoxSaldo.TabIndex = 5;
            // 
            // UsersName
            // 
            this.UsersName.HeaderText = "Користувачi";
            this.UsersName.Name = "UsersName";
            this.UsersName.ReadOnly = true;
            this.UsersName.Width = 200;
            // 
            // Expenses
            // 
            this.Expenses.HeaderText = "Витрати";
            this.Expenses.Name = "Expenses";
            this.Expenses.ReadOnly = true;
            this.Expenses.Width = 120;
            // 
            // Revenues
            // 
            this.Revenues.HeaderText = "Доходи";
            this.Revenues.Name = "Revenues";
            this.Revenues.ReadOnly = true;
            this.Revenues.Width = 120;
            // 
            // Saldo
            // 
            this.Saldo.HeaderText = "Сальдо";
            this.Saldo.Name = "Saldo";
            // 
            // SaldoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 631);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewSaldo);
            this.Controls.Add(this.btnClouse);
            this.Controls.Add(this.btnAply);
            this.Controls.Add(this.panelDate);
            this.Controls.Add(this.checkBoxDate);
            this.Name = "SaldoForm";
            this.Text = "SaldoForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaldo)).EndInit();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRevenues;
        private System.Windows.Forms.TextBox textBoxExpenses;
        private System.Windows.Forms.DataGridView dataGridViewSaldo;
        private System.Windows.Forms.Button btnClouse;
        private System.Windows.Forms.Button btnAply;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.DateTimePicker dateTimeFor;
        private System.Windows.Forms.CheckBox checkBoxDate;
        private System.Windows.Forms.TextBox textBoxSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revenues;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
    }
}