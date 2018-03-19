namespace Home_Bugaltery
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.довідникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.члениСімїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категоріїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операціяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRedactOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInitialRemains = new System.Windows.Forms.ToolStripMenuItem();
            this.звітиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всіДокументиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.витратиЗаПеріодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доходиЗаПеріодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зведенийЗвітToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сальдоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.допомогаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проРозробниківToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.довідникиToolStripMenuItem,
            this.операціяToolStripMenuItem,
            this.звітиToolStripMenuItem,
            this.допомогаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // довідникиToolStripMenuItem
            // 
            this.довідникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.члениСімїToolStripMenuItem,
            this.категоріїToolStripMenuItem});
            this.довідникиToolStripMenuItem.Name = "довідникиToolStripMenuItem";
            this.довідникиToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.довідникиToolStripMenuItem.Text = "Довідники";
            // 
            // члениСімїToolStripMenuItem
            // 
            this.члениСімїToolStripMenuItem.Name = "члениСімїToolStripMenuItem";
            this.члениСімїToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.члениСімїToolStripMenuItem.Text = "Члени сімї";
            // 
            // категоріїToolStripMenuItem
            // 
            this.категоріїToolStripMenuItem.Name = "категоріїToolStripMenuItem";
            this.категоріїToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.категоріїToolStripMenuItem.Text = "Доходи і витрати";
            // 
            // операціяToolStripMenuItem
            // 
            this.операціяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDocumentToolStripMenuItem,
            this.menuItemRedactOrder,
            this.menuItemInitialRemains});
            this.операціяToolStripMenuItem.Name = "операціяToolStripMenuItem";
            this.операціяToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.операціяToolStripMenuItem.Text = "Операції";
            // 
            // newDocumentToolStripMenuItem
            // 
            this.newDocumentToolStripMenuItem.Name = "newDocumentToolStripMenuItem";
            this.newDocumentToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.newDocumentToolStripMenuItem.Text = "Нова операція";
            this.newDocumentToolStripMenuItem.Click += new System.EventHandler(this.newDocumentToolStripMenuItem_Click);
            // 
            // menuItemRedactOrder
            // 
            this.menuItemRedactOrder.Name = "menuItemRedactOrder";
            this.menuItemRedactOrder.Size = new System.Drawing.Size(190, 22);
            this.menuItemRedactOrder.Text = "Редагувати операцію";
            this.menuItemRedactOrder.Click += new System.EventHandler(this.menuItemRedactOrder_Click);
            // 
            // menuItemInitialRemains
            // 
            this.menuItemInitialRemains.Name = "menuItemInitialRemains";
            this.menuItemInitialRemains.Size = new System.Drawing.Size(190, 22);
            this.menuItemInitialRemains.Text = "Початкові залишки";
            this.menuItemInitialRemains.Click += new System.EventHandler(this.menuItemInitialRemains_Click);
            // 
            // звітиToolStripMenuItem
            // 
            this.звітиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всіДокументиToolStripMenuItem,
            this.витратиЗаПеріодToolStripMenuItem,
            this.доходиЗаПеріодToolStripMenuItem,
            this.зведенийЗвітToolStripMenuItem,
            this.сальдоToolStripMenuItem});
            this.звітиToolStripMenuItem.Name = "звітиToolStripMenuItem";
            this.звітиToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.звітиToolStripMenuItem.Text = "Звіти";
            // 
            // всіДокументиToolStripMenuItem
            // 
            this.всіДокументиToolStripMenuItem.Name = "всіДокументиToolStripMenuItem";
            this.всіДокументиToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.всіДокументиToolStripMenuItem.Text = "Всі документи";
            // 
            // витратиЗаПеріодToolStripMenuItem
            // 
            this.витратиЗаПеріодToolStripMenuItem.Name = "витратиЗаПеріодToolStripMenuItem";
            this.витратиЗаПеріодToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.витратиЗаПеріодToolStripMenuItem.Text = "Витрати за період";
            // 
            // доходиЗаПеріодToolStripMenuItem
            // 
            this.доходиЗаПеріодToolStripMenuItem.Name = "доходиЗаПеріодToolStripMenuItem";
            this.доходиЗаПеріодToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.доходиЗаПеріодToolStripMenuItem.Text = "Доходи за період";
            // 
            // зведенийЗвітToolStripMenuItem
            // 
            this.зведенийЗвітToolStripMenuItem.Name = "зведенийЗвітToolStripMenuItem";
            this.зведенийЗвітToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.зведенийЗвітToolStripMenuItem.Text = "Зведений звіт за місяць";
            // 
            // сальдоToolStripMenuItem
            // 
            this.сальдоToolStripMenuItem.Name = "сальдоToolStripMenuItem";
            this.сальдоToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.сальдоToolStripMenuItem.Text = "Сальдо";
            // 
            // допомогаToolStripMenuItem
            // 
            this.допомогаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проРозробниківToolStripMenuItem});
            this.допомогаToolStripMenuItem.Name = "допомогаToolStripMenuItem";
            this.допомогаToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.допомогаToolStripMenuItem.Text = "Допомога";
            // 
            // проРозробниківToolStripMenuItem
            // 
            this.проРозробниківToolStripMenuItem.Name = "проРозробниківToolStripMenuItem";
            this.проРозробниківToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.проРозробниківToolStripMenuItem.Text = "Про розробників";
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.User,
            this.Date,
            this.Price,
            this.Description});
            this.dataGridViewOrders.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewOrders.Location = new System.Drawing.Point(25, 122);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.Size = new System.Drawing.Size(765, 326);
            this.dataGridViewOrders.TabIndex = 26;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // User
            // 
            this.User.HeaderText = "User";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 320;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Orders :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 516);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem довідникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операціяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem звітиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem члениСімїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категоріїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemRedactOrder;
        private System.Windows.Forms.ToolStripMenuItem menuItemInitialRemains;
        private System.Windows.Forms.ToolStripMenuItem витратиЗаПеріодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem доходиЗаПеріодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зведенийЗвітToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сальдоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem допомогаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проРозробниківToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всіДокументиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}

