namespace Home_Bugaltery
{
    partial class ExpensesRevenuesForPeriodForm
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
            this.panelDateFilter = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewEx = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.labelType = new System.Windows.Forms.Label();
            this.btnClouse = new System.Windows.Forms.Button();
            this.checkBoxDate = new System.Windows.Forms.CheckBox();
            this.panelDateFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDateFilter
            // 
            this.panelDateFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDateFilter.Controls.Add(this.label2);
            this.panelDateFilter.Controls.Add(this.label1);
            this.panelDateFilter.Controls.Add(this.dateTimePickerTo);
            this.panelDateFilter.Controls.Add(this.dateTimePickerDateFrom);
            this.panelDateFilter.Location = new System.Drawing.Point(163, 26);
            this.panelDateFilter.Name = "panelDateFilter";
            this.panelDateFilter.Size = new System.Drawing.Size(194, 109);
            this.panelDateFilter.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата до :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дата від :";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(25, 74);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerTo.TabIndex = 0;
            // 
            // dateTimePickerDateFrom
            // 
            this.dateTimePickerDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateFrom.Location = new System.Drawing.Point(25, 24);
            this.dateTimePickerDateFrom.Name = "dateTimePickerDateFrom";
            this.dateTimePickerDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerDateFrom.TabIndex = 0;
            // 
            // dataGridViewEx
            // 
            this.dataGridViewEx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.UserNames,
            this.Date,
            this.Summa});
            this.dataGridViewEx.Location = new System.Drawing.Point(6, 206);
            this.dataGridViewEx.Name = "dataGridViewEx";
            this.dataGridViewEx.Size = new System.Drawing.Size(545, 175);
            this.dataGridViewEx.TabIndex = 1;
            // 
            // Category
            // 
            this.Category.HeaderText = "Категорія";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // UserNames
            // 
            this.UserNames.HeaderText = "Nik";
            this.UserNames.Name = "UserNames";
            this.UserNames.ReadOnly = true;
            this.UserNames.Width = 200;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 120;
            // 
            // Summa
            // 
            this.Summa.HeaderText = "Сума";
            this.Summa.Name = "Summa";
            this.Summa.ReadOnly = true;
            this.Summa.Width = 80;
            // 
            // textBoxSum
            // 
            this.textBoxSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSum.Location = new System.Drawing.Point(259, 408);
            this.textBoxSum.Multiline = true;
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(110, 28);
            this.textBoxSum.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(52, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Загальна сума ";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(141, 152);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(228, 23);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Примінити фільтр";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelType.Location = new System.Drawing.Point(181, 409);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(0, 20);
            this.labelType.TabIndex = 5;
            // 
            // btnClouse
            // 
            this.btnClouse.Location = new System.Drawing.Point(207, 468);
            this.btnClouse.Name = "btnClouse";
            this.btnClouse.Size = new System.Drawing.Size(75, 23);
            this.btnClouse.TabIndex = 6;
            this.btnClouse.Text = "Закрити";
            this.btnClouse.UseVisualStyleBackColor = true;
            this.btnClouse.Click += new System.EventHandler(this.btnClouse_Click);
            // 
            // checkBoxDate
            // 
            this.checkBoxDate.AutoSize = true;
            this.checkBoxDate.Location = new System.Drawing.Point(167, 5);
            this.checkBoxDate.Name = "checkBoxDate";
            this.checkBoxDate.Size = new System.Drawing.Size(111, 17);
            this.checkBoxDate.TabIndex = 7;
            this.checkBoxDate.Text = "Фільтр по датам";
            this.checkBoxDate.UseVisualStyleBackColor = true;
            this.checkBoxDate.CheckedChanged += new System.EventHandler(this.checkBoxDate_CheckedChanged);
            // 
            // ExpensesRevenuesForPeriodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 503);
            this.Controls.Add(this.checkBoxDate);
            this.Controls.Add(this.btnClouse);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.dataGridViewEx);
            this.Controls.Add(this.panelDateFilter);
            this.Name = "ExpensesRevenuesForPeriodForm";
            this.panelDateFilter.ResumeLayout(false);
            this.panelDateFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDateFilter;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DataGridView dataGridViewEx;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summa;
        private System.Windows.Forms.Button btnClouse;
        private System.Windows.Forms.CheckBox checkBoxDate;
    }
}