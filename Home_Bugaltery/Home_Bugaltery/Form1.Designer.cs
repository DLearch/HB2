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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.довідникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUser = new System.Windows.Forms.ToolStripMenuItem();
            this.категоріїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panelFilters = new System.Windows.Forms.Panel();
            this.checkBoxDateFilter = new System.Windows.Forms.CheckBox();
            this.panelDateFilter = new System.Windows.Forms.Panel();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.checkBoxUserEnabletFilter = new System.Windows.Forms.CheckBox();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.panelUserFilter = new System.Windows.Forms.Panel();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.listBoxFilterUsers = new System.Windows.Forms.ListBox();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.panelCategoryFilter = new System.Windows.Forms.Panel();
            this.listBoxFilterCategories = new System.Windows.Forms.ListBox();
            this.btnRemoveCategoryFilter = new System.Windows.Forms.Button();
            this.btnAddCategoryFilter = new System.Windows.Forms.Button();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.checkBoxEnableCategoryFilter = new System.Windows.Forms.CheckBox();
            this.contextMenuCategories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.додатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редагуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelDateFilter.SuspendLayout();
            this.panelUserFilter.SuspendLayout();
            this.panelCategoryFilter.SuspendLayout();
            this.contextMenuCategories.SuspendLayout();
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
            this.menuItemUser,
            this.категоріїToolStripMenuItem,
            this.categoryToolStripMenuItem});
            this.довідникиToolStripMenuItem.Name = "довідникиToolStripMenuItem";
            this.довідникиToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.довідникиToolStripMenuItem.Text = "Довідники";
            // 
            // menuItemUser
            // 
            this.menuItemUser.Name = "menuItemUser";
            this.menuItemUser.Size = new System.Drawing.Size(166, 22);
            this.menuItemUser.Text = "Користувачі";
            this.menuItemUser.Click += new System.EventHandler(this.menuItemUser_Click);
            // 
            // категоріїToolStripMenuItem
            // 
            this.категоріїToolStripMenuItem.Name = "категоріїToolStripMenuItem";
            this.категоріїToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.категоріїToolStripMenuItem.Text = "Доходи і витрати";
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.categoryToolStripMenuItem.Text = "Категорії";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
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
            // 
            // menuItemInitialRemains
            // 
            this.menuItemInitialRemains.Name = "menuItemInitialRemains";
            this.menuItemInitialRemains.Size = new System.Drawing.Size(190, 22);
            this.menuItemInitialRemains.Text = "Початкові залишки";
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
            this.dataGridViewOrders.Location = new System.Drawing.Point(12, 277);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(765, 311);
            this.dataGridViewOrders.TabIndex = 26;
            this.dataGridViewOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellClick);
            this.dataGridViewOrders.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOrders_CellMouseClick);
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
            this.label3.Location = new System.Drawing.Point(25, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Orders :";
            // 
            // panelFilters
            // 
            this.panelFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilters.Controls.Add(this.checkBoxDateFilter);
            this.panelFilters.Controls.Add(this.panelDateFilter);
            this.panelFilters.Controls.Add(this.checkBoxUserEnabletFilter);
            this.panelFilters.Controls.Add(this.btnApplyFilters);
            this.panelFilters.Controls.Add(this.panelUserFilter);
            this.panelFilters.Controls.Add(this.panelCategoryFilter);
            this.panelFilters.Controls.Add(this.checkBoxEnableCategoryFilter);
            this.panelFilters.Location = new System.Drawing.Point(12, 37);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(765, 209);
            this.panelFilters.TabIndex = 27;
            // 
            // checkBoxDateFilter
            // 
            this.checkBoxDateFilter.AutoSize = true;
            this.checkBoxDateFilter.Location = new System.Drawing.Point(504, 3);
            this.checkBoxDateFilter.Name = "checkBoxDateFilter";
            this.checkBoxDateFilter.Size = new System.Drawing.Size(111, 17);
            this.checkBoxDateFilter.TabIndex = 7;
            this.checkBoxDateFilter.Text = "Enabled date filter";
            this.checkBoxDateFilter.UseVisualStyleBackColor = true;
            this.checkBoxDateFilter.CheckedChanged += new System.EventHandler(this.checkBoxDateFilter_CheckedChanged);
            // 
            // panelDateFilter
            // 
            this.panelDateFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDateFilter.Controls.Add(this.dateTimePickerTo);
            this.panelDateFilter.Controls.Add(this.label2);
            this.panelDateFilter.Controls.Add(this.label1);
            this.panelDateFilter.Controls.Add(this.dateTimePickerFrom);
            this.panelDateFilter.Location = new System.Drawing.Point(500, 26);
            this.panelDateFilter.Name = "panelDateFilter";
            this.panelDateFilter.Size = new System.Drawing.Size(166, 133);
            this.panelDateFilter.TabIndex = 6;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(14, 82);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(131, 20);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date to :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date from :";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(12, 23);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(133, 20);
            this.dateTimePickerFrom.TabIndex = 0;
            // 
            // checkBoxUserEnabletFilter
            // 
            this.checkBoxUserEnabletFilter.AutoSize = true;
            this.checkBoxUserEnabletFilter.Location = new System.Drawing.Point(207, 3);
            this.checkBoxUserEnabletFilter.Name = "checkBoxUserEnabletFilter";
            this.checkBoxUserEnabletFilter.Size = new System.Drawing.Size(110, 17);
            this.checkBoxUserEnabletFilter.TabIndex = 5;
            this.checkBoxUserEnabletFilter.Text = "Enabled user filter";
            this.checkBoxUserEnabletFilter.UseVisualStyleBackColor = true;
            this.checkBoxUserEnabletFilter.CheckedChanged += new System.EventHandler(this.checkBoxUserEnabletFilter_CheckedChanged);
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.Location = new System.Drawing.Point(3, 171);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(746, 26);
            this.btnApplyFilters.TabIndex = 1;
            this.btnApplyFilters.Text = "Apply filters";
            this.btnApplyFilters.UseVisualStyleBackColor = true;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // panelUserFilter
            // 
            this.panelUserFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserFilter.Controls.Add(this.btnRemoveUser);
            this.panelUserFilter.Controls.Add(this.btnAddUser);
            this.panelUserFilter.Controls.Add(this.listBoxFilterUsers);
            this.panelUserFilter.Controls.Add(this.comboBoxUsers);
            this.panelUserFilter.Location = new System.Drawing.Point(203, 24);
            this.panelUserFilter.Name = "panelUserFilter";
            this.panelUserFilter.Size = new System.Drawing.Size(147, 139);
            this.panelUserFilter.TabIndex = 0;
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(75, 109);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(59, 23);
            this.btnRemoveUser.TabIndex = 4;
            this.btnRemoveUser.Text = "Remove";
            this.btnRemoveUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(9, 109);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(55, 23);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // listBoxFilterUsers
            // 
            this.listBoxFilterUsers.FormattingEnabled = true;
            this.listBoxFilterUsers.Location = new System.Drawing.Point(9, 34);
            this.listBoxFilterUsers.Name = "listBoxFilterUsers";
            this.listBoxFilterUsers.Size = new System.Drawing.Size(125, 69);
            this.listBoxFilterUsers.TabIndex = 3;
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(9, 5);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(125, 21);
            this.comboBoxUsers.TabIndex = 1;
            // 
            // panelCategoryFilter
            // 
            this.panelCategoryFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCategoryFilter.Controls.Add(this.listBoxFilterCategories);
            this.panelCategoryFilter.Controls.Add(this.btnRemoveCategoryFilter);
            this.panelCategoryFilter.Controls.Add(this.btnAddCategoryFilter);
            this.panelCategoryFilter.Controls.Add(this.comboBoxCategories);
            this.panelCategoryFilter.Location = new System.Drawing.Point(3, 21);
            this.panelCategoryFilter.Name = "panelCategoryFilter";
            this.panelCategoryFilter.Size = new System.Drawing.Size(147, 144);
            this.panelCategoryFilter.TabIndex = 0;
            // 
            // listBoxFilterCategories
            // 
            this.listBoxFilterCategories.FormattingEnabled = true;
            this.listBoxFilterCategories.Location = new System.Drawing.Point(9, 34);
            this.listBoxFilterCategories.Name = "listBoxFilterCategories";
            this.listBoxFilterCategories.Size = new System.Drawing.Size(125, 69);
            this.listBoxFilterCategories.TabIndex = 3;
            // 
            // btnRemoveCategoryFilter
            // 
            this.btnRemoveCategoryFilter.Location = new System.Drawing.Point(79, 112);
            this.btnRemoveCategoryFilter.Name = "btnRemoveCategoryFilter";
            this.btnRemoveCategoryFilter.Size = new System.Drawing.Size(55, 23);
            this.btnRemoveCategoryFilter.TabIndex = 2;
            this.btnRemoveCategoryFilter.Text = "Remove";
            this.btnRemoveCategoryFilter.UseVisualStyleBackColor = true;
            this.btnRemoveCategoryFilter.Click += new System.EventHandler(this.btnRemoveCategoryFilter_Click);
            // 
            // btnAddCategoryFilter
            // 
            this.btnAddCategoryFilter.Location = new System.Drawing.Point(11, 112);
            this.btnAddCategoryFilter.Name = "btnAddCategoryFilter";
            this.btnAddCategoryFilter.Size = new System.Drawing.Size(52, 23);
            this.btnAddCategoryFilter.TabIndex = 2;
            this.btnAddCategoryFilter.Text = "Add";
            this.btnAddCategoryFilter.UseVisualStyleBackColor = true;
            this.btnAddCategoryFilter.Click += new System.EventHandler(this.btnAddCategoryFilter_Click);
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(9, 5);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(125, 21);
            this.comboBoxCategories.TabIndex = 1;
            // 
            // checkBoxEnableCategoryFilter
            // 
            this.checkBoxEnableCategoryFilter.AutoSize = true;
            this.checkBoxEnableCategoryFilter.Location = new System.Drawing.Point(13, 3);
            this.checkBoxEnableCategoryFilter.Name = "checkBoxEnableCategoryFilter";
            this.checkBoxEnableCategoryFilter.Size = new System.Drawing.Size(125, 17);
            this.checkBoxEnableCategoryFilter.TabIndex = 0;
            this.checkBoxEnableCategoryFilter.Text = "Enable category filter";
            this.checkBoxEnableCategoryFilter.UseVisualStyleBackColor = true;
            this.checkBoxEnableCategoryFilter.CheckedChanged += new System.EventHandler(this.checkBoxEnableCategoryFilter_CheckedChanged);
            // 
            // contextMenuCategories
            // 
            this.contextMenuCategories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиToolStripMenuItem,
            this.редагуватиToolStripMenuItem});
            this.contextMenuCategories.Name = "contextMenuCategories";
            this.contextMenuCategories.Size = new System.Drawing.Size(135, 48);
            // 
            // додатиToolStripMenuItem
            // 
            this.додатиToolStripMenuItem.Name = "додатиToolStripMenuItem";
            this.додатиToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.додатиToolStripMenuItem.Text = "Додати";
            // 
            // редагуватиToolStripMenuItem
            // 
            this.редагуватиToolStripMenuItem.Name = "редагуватиToolStripMenuItem";
            this.редагуватиToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.редагуватиToolStripMenuItem.Text = "Редагувати";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 600);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelDateFilter.ResumeLayout(false);
            this.panelDateFilter.PerformLayout();
            this.panelUserFilter.ResumeLayout(false);
            this.panelCategoryFilter.ResumeLayout(false);
            this.contextMenuCategories.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem довідникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операціяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem звітиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemUser;
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
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Panel panelCategoryFilter;
        private System.Windows.Forms.ListBox listBoxFilterCategories;
        private System.Windows.Forms.Button btnAddCategoryFilter;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.CheckBox checkBoxEnableCategoryFilter;
        private System.Windows.Forms.Button btnRemoveCategoryFilter;
        private System.Windows.Forms.Panel panelUserFilter;
        private System.Windows.Forms.ListBox listBoxFilterUsers;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.CheckBox checkBoxUserEnabletFilter;
        private System.Windows.Forms.CheckBox checkBoxDateFilter;
        private System.Windows.Forms.Panel panelDateFilter;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.ContextMenuStrip contextMenuCategories;
        private System.Windows.Forms.ToolStripMenuItem додатиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редагуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
    }
}

