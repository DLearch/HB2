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

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        NewDocumentForm newDocument;

        public Form1()
        {
            InitializeComponent();

            homeBugaltery = new HomeBugaltery();
            actHomeBogaltery = new HomeBugalteryAction();

            newDocument = new NewDocumentForm(homeBugaltery, actHomeBogaltery);

            updateOrdersGrid();
            updateCategorys();
        }


        private void updateOrdersGrid()
        {

            dataGridViewOrders.Rows.Clear();
            foreach (OrdersView orderView in homeBugaltery.ListOrders)
            {
                //var categoryName = homeBugaltery.
                int rowIndex = dataGridViewOrders.Rows.Add(orderView.CategoryName);
                dataGridViewOrders.Rows[rowIndex].Cells[1].Value = orderView.UserName;
                dataGridViewOrders.Rows[rowIndex].Cells[2].Value = orderView.DateOrder;
                dataGridViewOrders.Rows[rowIndex].Cells[3].Value = orderView.Price;
                dataGridViewOrders.Rows[rowIndex].Cells[4].Value = orderView.Description;

            }
        }
        private void updateCategorys()
        {
            comboBoxCategories.Items.Clear();

            foreach (Categories_HB category in homeBugaltery.ListCategories)
            {
                comboBoxCategories.Items.Add(category.Name);
                comboBoxCategories.SelectedIndex = 0;
            }
        }



        private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDocument.ShowDialog();

            updateOrdersGrid();
        }

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


        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            if (checkBoxEnableCategoryFilter.Checked == false)
            {
                homeBugaltery.ClearOrdersFilters();
                updateOrdersGrid();
                return;
            }

            //Categories
            List<string> categoriesList = new List<string>();
            categoriesList.AddRange(listBoxFilterCategories.Items.Cast<string>());
            //actHomeBogaltery.SetCommand(HomeActionEnum.addOrder, new homeBugaltery.aplyOrdersFilters(categoriesList));
            homeBugaltery.aplyOrdersFilters(categoriesList);


            //Users


            //Dates

            updateOrdersGrid();
        }
    }
}
