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
    public partial class NewCategoryForm : Form
    {
        bool type = false;

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        public NewCategoryForm(HomeBugaltery homeBugaltery, HomeBugalteryAction actHomeBogaltery)
        {
            InitializeComponent();

            this.homeBugaltery = homeBugaltery;
            this.actHomeBogaltery = actHomeBogaltery;

            updateCategory();


            comboBoxType.SelectedIndex = 0;
        }

        //public void showForm(int orderId = -1)
        //{          
        //    ShowDialog();
        //}

        private void updateCategory()
        {
            comboBoxCategory.Items.Clear();

            foreach (Categories category in homeBugaltery.ListCategories)
            {
                comboBoxCategory.Items.Add(category.Name);
            }
            comboBoxCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxNameCategory.Text == "" && comboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("Cannot add category!\nPlease check inputed data and try again!!!");
                return;
            }

            if (comboBoxCategory.SelectedIndex == 1)
                type = true;
            actHomeBogaltery.SetCommand((int)HomeActionEnum.addCategory, new AddCategoryCommand(homeBugaltery, textBoxNameCategory.Text, type));

            actHomeBogaltery.DoAction((int)HomeActionEnum.addCategory);

            updateCategory();

            textBoxNameCategory.Clear();
        }

        private void textBoxNameCategory_TextChanged(object sender, EventArgs e)
        {
            textBoxNameCategory.Clear();
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
