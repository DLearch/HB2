﻿using ClassLibrary1;
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

            updateCategorysFilter();
            updateUsersFilter();

            panelUserFilter.Enabled = checkBoxUserEnabletFilter.Checked;
            panelCategoryFilter.Enabled = checkBoxEnableCategoryFilter.Checked;
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
        private void updateCategorysFilter()
        {
            comboBoxCategories.Items.Clear();

            foreach (Categories category in homeBugaltery.ListCategories)
            {
                comboBoxCategories.Items.Add(category.Name);
                comboBoxCategories.SelectedIndex = 0;
            }
        }
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
            newDocument.ShowDialog();

            updateOrdersGrid();
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


        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            if (checkBoxEnableCategoryFilter.Checked == false && checkBoxUserEnabletFilter.Checked == false && checkBoxDateFilter.Checked == false)
            {
                homeBugaltery.ClearOrdersFilters();
                updateOrdersGrid();
                return;
            }

            List<string> categoriesList = null;
            List<string> usersList = null;
            string dateFrom = "";
            string dateTo = "";


            //Categories
            if (checkBoxEnableCategoryFilter.Checked && listBoxFilterCategories.Items.Count > 0)
            {
                categoriesList = new List<string>();
                categoriesList.AddRange(listBoxFilterCategories.Items.Cast<string>());
            }

            //Users
            if (checkBoxUserEnabletFilter.Checked && listBoxFilterUsers.Items.Count > 0)
            {
                usersList = new List<string>();
                usersList.AddRange(listBoxFilterUsers.Items.Cast<string>());
            }

            // Date
            if(checkBoxDateFilter.Checked)
            {
                dateFrom = dateTimePickerFrom.Value.ToString();
                dateTo = dateTimePickerTo.Value.ToString();
            }

            homeBugaltery.aplyOrdersFilters(categoriesList, usersList, dateFrom, dateTo);

            //Dates

            updateOrdersGrid();
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxUserEnabletFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelUserFilter.Enabled = checkBoxUserEnabletFilter.Checked;
            if (checkBoxUserEnabletFilter.Checked == false)
                listBoxFilterUsers.Items.Clear();
        }

        private void checkBoxEnableCategoryFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelCategoryFilter.Enabled = checkBoxEnableCategoryFilter.Checked;
            if (checkBoxUserEnabletFilter.Checked == false)
                listBoxFilterCategories.Items.Clear();
        }

        private void checkBoxDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            //panelDateFilter.Enabled = checkBoxDateFilter.Checked;
            checkBoxDateFilter.Enabled = false;
        }
    }
}
