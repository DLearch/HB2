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
    public partial class Form1 : Form
    {
        ContextMenu dataGridContextMenu;

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        NewOrderForm newOrder;
        ModifiCategoryForm newAddcategory;

        ModifiUserForm addChangeUser;

        Users curentUser;

        bool isFiltersActive = false;


        public Form1(/*Users curentUser*/)
        {
            InitializeComponent();

            curentUser = new Users() { Id = 1, Email = "nina_3@email.com", Name = "НінаНікитюк", Password = "1234", Family_Id = 1 };
           // this.curentUser = curentUser;

            // ContextMenu for dataGrid "Edit", "delete"
            dataGridContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Edit", new EventHandler(onContextEditClick)),
                                                                   new MenuItem("Delete", new EventHandler(onContextDeleteClick))});

            dataGridViewOrders.ContextMenu = dataGridContextMenu;



            homeBugaltery = new HomeBugaltery();
            actHomeBogaltery = new HomeBugalteryAction();

            newOrder = new NewOrderForm(homeBugaltery, actHomeBogaltery);

            // Update
            updateOrdersGrid();

            updateCategorysFilter();
            updateUsersFilter();


            panelUserFilter.Enabled = checkBoxUserEnabletFilter.Checked;
            panelCategoryFilter.Enabled = checkBoxEnableCategoryFilter.Checked;
            panelDateFilter.Enabled = checkBoxDateFilter.Checked;
        }


        private void updateOrdersGrid()
        {
            List<OrdersView> orders = isFiltersActive ? homeBugaltery.FilteredListOrders : homeBugaltery.ListOrders;
            dataGridViewOrders.Rows.Clear();
            foreach (OrdersView orderView in orders)
            {
                
                int rowIndex = dataGridViewOrders.Rows.Add(orderView.CategoryName);
                dataGridViewOrders.Rows[rowIndex].Cells[1].Value = orderView.UserName;
                dataGridViewOrders.Rows[rowIndex].Cells[2].Value = orderView.DateOrder;
                dataGridViewOrders.Rows[rowIndex].Cells[3].Value = orderView.Price;
                dataGridViewOrders.Rows[rowIndex].Cells[4].Value = orderView.Description;
                //Tag - id order
                dataGridViewOrders.Rows[rowIndex].Tag = orderView.Id;

            }
        }

        // Update Filter Category
        private void updateCategorysFilter()
        {
            comboBoxCategories.Items.Clear();

            foreach (Categories category in homeBugaltery.ListCategories)
            {
                comboBoxCategories.Items.Add(category.Name);
                comboBoxCategories.SelectedIndex = 0;
            }
        }
        // Update Filter User
        private void updateUsersFilter()
        {
            comboBoxUsers.Items.Clear();

            foreach (Users user in homeBugaltery.ListUsers)
            {
                comboBoxUsers.Items.Add(user.Name);
                comboBoxUsers.SelectedIndex = 0;
            }
        }

        // New Orders
        private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newOrder.showForm();

            updateOrdersGrid();
        }

        // New Category
        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newAddcategory = new ModifiCategoryForm(homeBugaltery, actHomeBogaltery);
            newAddcategory.ShowDialog();//.showForm();
        }

        // Filter for category
        private void btnAddCategoryFilter_Click(object sender, EventArgs e)
        {
            listBoxFilterCategories.Items.Add(comboBoxCategories.SelectedItem.ToString());    
        }

        private void btnRemoveCategoryFilter_Click(object sender, EventArgs e)
        {
            object selectedCategory = listBoxFilterCategories.SelectedItem;
            if (selectedCategory != null)
                listBoxFilterCategories.Items.Remove(selectedCategory);
        }

        // Filter for Users
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            listBoxFilterUsers.Items.Add(comboBoxUsers.SelectedItem.ToString());
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            object selectedUser = listBoxFilterUsers.SelectedItem;

            if (listBoxFilterUsers != null)
                listBoxFilterUsers.Items.Remove(selectedUser);
        }

        // Apply filter
        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            List<string> categoriesList = null;
            List<string> usersList = null;
            DateTime? dateFrom = null;
            DateTime? dateTo = null;
            isFiltersActive = false;

            //Categories
            if (checkBoxEnableCategoryFilter.Checked && listBoxFilterCategories.Items.Count > 0)
            {
                isFiltersActive = true;
                categoriesList = new List<string>();
                categoriesList.AddRange(listBoxFilterCategories.Items.Cast<string>());
            }

            //Users
            if (checkBoxUserEnabletFilter.Checked && listBoxFilterUsers.Items.Count > 0)
            {
                isFiltersActive = true;
                usersList = new List<string>();
                usersList.AddRange(listBoxFilterUsers.Items.Cast<string>());
            }

            // Date
            if(checkBoxDateFilter.Checked)
            {
                isFiltersActive = true;
                dateFrom = dateTimePickerFrom.Value;
                dateTo = dateTimePickerTo.Value;
            }

            if (isFiltersActive)
                homeBugaltery.aplyOrdersFilters(categoriesList, usersList, dateFrom, dateTo);

            updateOrdersGrid();
        }



        // checkBoxUserFilter
        private void checkBoxUserEnabletFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelUserFilter.Enabled = checkBoxUserEnabletFilter.Checked;
            if (checkBoxUserEnabletFilter.Checked == false)
                listBoxFilterUsers.Items.Clear();
        }

        //checkBoxCategoryFilter
        private void checkBoxEnableCategoryFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelCategoryFilter.Enabled = checkBoxEnableCategoryFilter.Checked;
            if (checkBoxUserEnabletFilter.Checked == false)
                listBoxFilterCategories.Items.Clear();
        }

        //checkBoxDateFilter
        private void checkBoxDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelDateFilter.Enabled = checkBoxDateFilter.Checked;
            
        }

        private void dataGridViewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewOrders.ClearSelection();
                dataGridViewOrders.Rows[e.RowIndex].Selected = true;
                dataGridViewOrders.ContextMenu.Show(dataGridViewOrders, dataGridViewOrders.PointToClient(Cursor.Position));
            }
        }

        //Context menu (edit) on clik order
        private void onContextEditClick(object o, EventArgs ea)
        {
            newOrder.showForm((int)dataGridViewOrders.SelectedRows[0].Tag);
            updateOrdersGrid();
        }

        //Context menu (delete) on clik order
        private void onContextDeleteClick(object o, EventArgs ea)
        {
            MessageBox.Show("Видалити? \nВи впевнені?");

            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                // Delete for Id - ((int)dataGridViewOrders.SelectedRows[0].Tag)
                homeBugaltery.deleteOrder((int)dataGridViewOrders.SelectedRows[0].Tag);
            }

            updateOrdersGrid();
        }

        private void menuItemUser_Click(object sender, EventArgs e)
        {
            addChangeUser = new ModifiUserForm(curentUser, homeBugaltery, actHomeBogaltery);
            addChangeUser.ShowDialog();
        }

        // For revenues
        private void menuItemRevenues_Click(object sender, EventArgs e)
        {
            bool type = true;

            ExpensesRevenuesForPeriodForm expForm = new ExpensesRevenuesForPeriodForm(type, homeBugaltery);
            expForm.ShowDialog();
        }

        // Expenses Form
        private void menuItemCosts_Click(object sender, EventArgs e)
        {
            bool type = false;

            ExpensesRevenuesForPeriodForm expForm = new ExpensesRevenuesForPeriodForm(type, homeBugaltery);
            expForm.ShowDialog();
        }

        private void menuItemSaldo_Click(object sender, EventArgs e)
        {
            SaldoForm saldoForm = new SaldoForm(homeBugaltery);
            saldoForm.ShowDialog();
        }
    }
}
