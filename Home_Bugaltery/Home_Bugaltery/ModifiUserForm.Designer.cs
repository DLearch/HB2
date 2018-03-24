namespace Home_Bugaltery
{
    partial class ModifiUserForm
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
            this.panelAllUser = new System.Windows.Forms.Panel();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelNewUser = new System.Windows.Forms.Panel();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.btnChangeDataCurentUser = new System.Windows.Forms.Button();
            this.btnClouse = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.panelAllUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.panelNewUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAllUser
            // 
            this.panelAllUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAllUser.Controls.Add(this.btnDelete);
            this.panelAllUser.Controls.Add(this.dataGridViewUsers);
            this.panelAllUser.Location = new System.Drawing.Point(46, 29);
            this.panelAllUser.Name = "panelAllUser";
            this.panelAllUser.Size = new System.Drawing.Size(399, 226);
            this.panelAllUser.TabIndex = 0;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Email,
            this.Nik});
            this.dataGridViewUsers.Location = new System.Drawing.Point(26, 15);
            this.dataGridViewUsers.MultiSelect = false;
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(340, 165);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.SelectionChanged += new System.EventHandler(this.dataGridViewUsers_SelectionChanged);
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 200;
            // 
            // Nik
            // 
            this.Nik.HeaderText = "Nik";
            this.Nik.Name = "Nik";
            this.Nik.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(108, 186);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Видалити вибраного користувача";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelNewUser
            // 
            this.panelNewUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelNewUser.Controls.Add(this.textBoxPass);
            this.panelNewUser.Controls.Add(this.label4);
            this.panelNewUser.Controls.Add(this.textBoxName);
            this.panelNewUser.Controls.Add(this.label3);
            this.panelNewUser.Controls.Add(this.textBoxEmail);
            this.panelNewUser.Controls.Add(this.label2);
            this.panelNewUser.Controls.Add(this.btnSave);
            this.panelNewUser.Location = new System.Drawing.Point(76, 333);
            this.panelNewUser.Name = "panelNewUser";
            this.panelNewUser.Size = new System.Drawing.Size(336, 143);
            this.panelNewUser.TabIndex = 0;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(89, 67);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(177, 20);
            this.textBoxPass.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "пароль :";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(105, 41);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(146, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nik :";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(89, 15);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(188, 20);
            this.textBoxEmail.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "email :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 102);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Користувачі :";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(79, 314);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 13);
            this.labelUser.TabIndex = 2;
            // 
            // btnChangeDataCurentUser
            // 
            this.btnChangeDataCurentUser.Location = new System.Drawing.Point(92, 261);
            this.btnChangeDataCurentUser.Name = "btnChangeDataCurentUser";
            this.btnChangeDataCurentUser.Size = new System.Drawing.Size(122, 23);
            this.btnChangeDataCurentUser.TabIndex = 3;
            this.btnChangeDataCurentUser.Text = "Змінити мої дані";
            this.btnChangeDataCurentUser.UseVisualStyleBackColor = true;
            this.btnChangeDataCurentUser.Click += new System.EventHandler(this.btnChangeDataCurentUser_Click);
            // 
            // btnClouse
            // 
            this.btnClouse.Location = new System.Drawing.Point(183, 482);
            this.btnClouse.Name = "btnClouse";
            this.btnClouse.Size = new System.Drawing.Size(109, 23);
            this.btnClouse.TabIndex = 4;
            this.btnClouse.Text = "Закрити";
            this.btnClouse.UseVisualStyleBackColor = true;
            this.btnClouse.Click += new System.EventHandler(this.btnClouse_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(248, 261);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(166, 23);
            this.btnNewUser.TabIndex = 5;
            this.btnNewUser.Text = "Додати нового користувача";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // ModifiUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 519);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnClouse);
            this.Controls.Add(this.btnChangeDataCurentUser);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelNewUser);
            this.Controls.Add(this.panelAllUser);
            this.Name = "ModifiUserForm";
            this.Text = "ModifiUserForm";
            this.panelAllUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.panelNewUser.ResumeLayout(false);
            this.panelNewUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAllUser;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Panel panelNewUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nik;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnChangeDataCurentUser;
        private System.Windows.Forms.Button btnClouse;
        private System.Windows.Forms.Button btnNewUser;
    }
}