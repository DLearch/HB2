using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace Home_Bugaltery
{
    enum organiserActionEnum
    {
        addOrder = 0,
        
    }
    public partial class NewDocumentForm : Form
    {
        //BisnesLogic bisnesLogic;

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        public NewDocumentForm()
        {
            InitializeComponent();
            //bisnesLogic = new BisnesLogic();

            homeBugaltery = new HomeBugaltery();
            actHomeBogaltery = new HomeBugalteryAction();

            updateCategorys();
            updateUsers();

        }

        private void updateCategorys()
        {
            comboBoxCategory.Items.Clear();

            foreach(Categories category in homeBugaltery.ListCategories)
            {
                comboBoxCategory.Items.Add(category.Name);
                comboBoxCategory.SelectedIndex = 0;
            }
        }

        private void updateUsers()
        {
            comboBoxUsers.Items.Clear();

            foreach (Users user in homeBugaltery.ListUsers)
            {
                comboBoxUsers.Items.Add(user.Name);
                comboBoxUsers.SelectedIndex = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dateTimePickerOrder.Text != "")
            {
                actHomeBogaltery.SetCommand((int)organiserActionEnum.addOrder,
                                             new AddNewOrderCommand(homeBugaltery, comboBoxCategory.SelectedItem.ToString(), comboBoxUsers.SelectedItem.ToString(),
                                                                    dateTimePickerOrder.Value, numericUpDownSumm.Value,
                                                                    textBoxDescription.Text));
                actHomeBogaltery.PressButton((int)organiserActionEnum.addOrder);
            }
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
