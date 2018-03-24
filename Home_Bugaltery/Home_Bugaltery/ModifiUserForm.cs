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
        int selectUserId = 0;


        public ModifiUserForm(Users curentUser, HomeBugaltery homeBugaltery, HomeBugalteryAction actHomeBogaltery)
        {
            InitializeComponent();

            this.homeBugaltery = homeBugaltery;
            this.actHomeBugaltery = actHomeBogaltery;

            this.curentUser = curentUser;

            updateUsers();
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

        private void enabledForm(bool typ)
        {
            textBoxEmail.Enabled = typ;
            textBoxName.Enabled = typ;
            textBoxPass.Enabled = typ;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            enabledForm(false);

            selectUserId = (int)dataGridViewUsers.SelectedRows[0].Tag;

            selectUserToDelete = homeBugaltery.ListUsers.Find(us => us.Id == selectUserId);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "" && textBoxName.Text != "" && textBoxPass.Text != null)
            {
                MessageBox.Show("Нового користувача не додано!\nПопробуйте ще раз!!!");
                return;
            }

            actHomeBugaltery.SetCommand((int)HomeActionEnum.addNewUser, new AddNewUserCommand(homeBugaltery, textBoxEmail.Text, textBoxName.Text,
                                                                                              textBoxPass.Text));

            actHomeBugaltery.DoAction((int)HomeActionEnum.addNewUser);

            updateUsers();

            textBoxEmail.Clear();
            textBoxName.Clear();
            textBoxPass.Clear();

        }

        private void btnChangeDataCurentUser_Click(object sender, EventArgs e)
        {
            enabledForm(true);
            actHomeBugaltery.SetCommand((int)HomeActionEnum.changeDataCurentUser, new ChangeCurentUserCommand(homeBugaltery,
                                                           curentUser.Id, textBoxEmail.Text, textBoxName.Text, textBoxPass.Text));

            actHomeBugaltery.DoAction((int)HomeActionEnum.changeDataCurentUser);
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
