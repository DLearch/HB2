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
    enum HomeActionEnum
    {
        addOrder = 0,
        changeOrder = 1,
        addCategory = 2
    }
    public partial class NewOrderForm : Form
    {
        OrdersView currentOrder = null;       
        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        public NewOrderForm(HomeBugaltery homeBugaltery, HomeBugalteryAction actHomeBogaltery)
        {
            InitializeComponent();

            this.homeBugaltery = homeBugaltery;
            this.actHomeBogaltery = actHomeBogaltery;
        }

        public void showForm(int orderId = -1)
        {
           
            currentOrder = homeBugaltery.ListOrders.Find(x => x.Id == orderId);
            updateForm();
            ShowDialog();
        }

        private void updateCategorys()
        {
            comboBoxCategory.Items.Clear();

            foreach(Categories category in homeBugaltery.ListCategories)
            {
                comboBoxCategory.Items.Add(category.Name);
            }
            comboBoxCategory.SelectedIndex = 0;
        }

        private void updateUsers()
        {
            comboBoxUsers.Items.Clear();

            foreach (Users user in homeBugaltery.ListUsers)
            {
                comboBoxUsers.Items.Add(user.Name);
            }
            comboBoxUsers.SelectedIndex = 0;
        }

        private void updateForm()
        {
            updateCategorys();
            updateUsers();

            if (currentOrder != null)
            {
                comboBoxCategory.SelectedItem = currentOrder.CategoryName;
                comboBoxUsers.SelectedItem = currentOrder.UserName;
                dateTimePickerOrder.Value = currentOrder.DateOrder;
                numericUpDownSumm.Value = currentOrder.Price;
                textBoxDescription.Text = currentOrder.Description;
            }
            else
            {
                numericUpDownSumm.Value = 0;
                textBoxDescription.Text = "";
                dateTimePickerOrder.Value = DateTime.Now;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedIndex == -1 || comboBoxUsers.SelectedIndex == -1 
                || numericUpDownSumm.Value <= 0)
            {
                MessageBox.Show("Cannot add order!\nPlease check inputed data and try again!!!");
                return;
            }
            // Command change
            if (currentOrder != null)
            {
                // MessageBox.Show("Need to implement edit logics");
                actHomeBogaltery.SetCommand((int)HomeActionEnum.changeOrder, new ChangeOrderCommand(homeBugaltery, currentOrder.Id,
                                                                            comboBoxCategory.SelectedItem.ToString(), comboBoxUsers.SelectedItem.ToString(),
                                                                            dateTimePickerOrder.Value, numericUpDownSumm.Value,
                                                                            textBoxDescription.Text));
                actHomeBogaltery.DoAction((int)HomeActionEnum.changeOrder);
            }
            else
            {
                actHomeBogaltery.SetCommand((int)HomeActionEnum.addOrder,
                                                new AddNewOrderCommand(homeBugaltery, comboBoxCategory.SelectedItem.ToString(), comboBoxUsers.SelectedItem.ToString(),
                                                                    dateTimePickerOrder.Value, numericUpDownSumm.Value,
                                                                    textBoxDescription.Text));
                actHomeBogaltery.DoAction((int)HomeActionEnum.addOrder);
            }
            
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
