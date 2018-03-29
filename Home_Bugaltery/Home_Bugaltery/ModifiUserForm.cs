using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Bugaltery
{
    public partial class ModifiUserForm : Form
    {

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBugaltery;

        private Users curentUser;

        Users selectUserToDelete = null;

        bool IsChangeMyData = false;

        public ModifiUserForm(Users curentUser, HomeBugaltery homeBugaltery, HomeBugalteryAction actHomeBogaltery)
        {
            InitializeComponent();

            // title Family name
            this.Text = homeBugaltery.getFamilyName(curentUser.Family_Id);

            this.homeBugaltery = homeBugaltery;
            this.actHomeBugaltery = actHomeBogaltery;

            this.curentUser = curentUser;

            updateUsers();

            enabledForm(false);
        }

        private void updateUsers()
        {
            dataGridViewUsers.Rows.Clear();


     
            foreach (Users user in homeBugaltery.ListUsers)
            {
                int rowIndex = dataGridViewUsers.Rows.Add(user.Email);
                dataGridViewUsers.Rows[rowIndex].Cells[1].Value = user.Name;

                dataGridViewUsers.Rows[rowIndex].Tag = user.Id;
            }


        }

        private void enabledForm(bool type)
        {
            //textBoxEmail.Enabled = type;
            //textBoxName.Enabled = type;
            //textBoxPass.Enabled = type;
            panelNewUser.Enabled = type;
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridViewUsers.SelectedRows.Count == 0 || dataGridViewUsers.SelectedRows[0].Tag == null)
            {
                selectUserToDelete = null;
                return;
            }
            enabledForm(false);
            panelAllUser.Enabled = true;

            var selectUserId = (int)dataGridViewUsers.SelectedRows[0].Tag;

            selectUserToDelete = homeBugaltery.ListUsers.Find(us => us.Id == selectUserId);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Видалити? \nВи впевнені?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dataGridViewUsers.SelectedRows.Count > 0)
                {
                    try
                    {
                        homeBugaltery.deleteUser(selectUserToDelete.Id);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Не можливо видалити користувача!!!\nДетально:\n" + exc.Message, "Помилка!!!");
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                return;
            }
            updateUsers();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "" && textBoxName.Text != "" && textBoxPass.Text != null)
            {
                MessageBox.Show("Нового користувача не додано!\nПопробуйте ще раз!!!");
                return;
            }

            // Change my data
            if (IsChangeMyData == true)
            {
                actHomeBugaltery.SetCommand((int)HomeActionEnum.changeDataCurentUser, new ChangeCurentUserCommand(homeBugaltery,
                                                              curentUser.Id, textBoxEmail.Text, textBoxName.Text, textBoxPass.Text/*, curentUser.Family_Id*/));

                actHomeBugaltery.DoAction((int)HomeActionEnum.changeDataCurentUser);
            }
            else // add new User
            {
                actHomeBugaltery.SetCommand((int)HomeActionEnum.addNewUser, new AddNewUserCommand(homeBugaltery, textBoxEmail.Text, textBoxName.Text,
                                                                                                  textBoxPass.Text, curentUser.Family_Id));

                actHomeBugaltery.DoAction((int)HomeActionEnum.addNewUser);
            }

            updateUsers();
            panelAllUser.Enabled = true;

            textBoxEmail.Clear();
            textBoxName.Clear();
            textBoxPass.Clear();

        }

        private void btnChangeDataCurentUser_Click(object sender, EventArgs e)
        {
            enabledForm(true);

            IsChangeMyData = true;

            //Go to the last ROW in GRID
            int lastIndex = dataGridViewUsers.Rows.Count - 1;
            dataGridViewUsers.Rows[lastIndex].Selected = true;
            dataGridViewUsers.FirstDisplayedScrollingRowIndex = lastIndex;

            textBoxEmail.Text = curentUser.Email;
            textBoxName.Text = curentUser.Name;
            textBoxPass.Text = curentUser.Password;

           // dataGridViewUsers.SelectedRows[curentUser.Id];
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            labelUser.Text = "Новий користувач :";

            panelAllUser.Enabled = false;
            IsChangeMyData = false;

            //Go to the last ROW in GRID
            int lastIndex = dataGridViewUsers.Rows.Count - 1;
            dataGridViewUsers.Rows[lastIndex].Selected = true;
            dataGridViewUsers.FirstDisplayedScrollingRowIndex = lastIndex;

            textBoxEmail.Clear();
            textBoxName.Clear();
            textBoxPass.Clear();

            enabledForm(true);
        }
    }
}
