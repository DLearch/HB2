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
    public partial class ExpensesRevenuesForPeriodForm : Form
    {
        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        bool type;
        decimal sum;

        public ExpensesRevenuesForPeriodForm(bool type)
        {
            InitializeComponent();

            this.type = type;

            homeBugaltery = new HomeBugaltery();
            actHomeBogaltery = new HomeBugalteryAction();

            if (type == false)
                this.Text = "Витрати за період";
            else
                this.Text = "Доходи за період";

            if (type == false)
                labelType.Text = "витрат : ";
            else
                labelType.Text = "доходів : ";

            sum = homeBugaltery.applyFiltersForExpensRevenues(type);
            updateTable();

            panelDateFilter.Enabled = checkBoxDate.Checked;

        }

        private void updateTable()
        {
            
            dataGridViewEx.Rows.Clear();

            foreach (OrdersView order in homeBugaltery.FilterOrderExpensRevenues)
            {
                int rowIndex = dataGridViewEx.Rows.Add(order.CategoryName);
                dataGridViewEx.Rows[rowIndex].Cells[1].Value = order.UserName;
                dataGridViewEx.Rows[rowIndex].Cells[2].Value = order.DateOrder;
                dataGridViewEx.Rows[rowIndex].Cells[3].Value = order.Price;
                //Tag - id order
                dataGridViewEx.Rows[rowIndex].Tag = order.Id;
            }

            textBoxSum.Text = sum.ToString();

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (checkBoxDate.Checked)
                sum = homeBugaltery.applyFiltersForExpensRevenues(type, dateTimePickerDateFrom.Value, dateTimePickerTo.Value);
            else
                sum = homeBugaltery.applyFiltersForExpensRevenues(type);

            updateTable();
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //checkBoxDateFilter
        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            panelDateFilter.Enabled = checkBoxDate.Checked;
        }
    }
}
