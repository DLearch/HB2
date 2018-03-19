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

     

        private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDocument.ShowDialog();

            updateOrdersGrid();
        }

        private void menuItemRedactOrder_Click(object sender, EventArgs e)
        {

        }

        private void menuItemInitialRemains_Click(object sender, EventArgs e)
        {

        }
    }
}
