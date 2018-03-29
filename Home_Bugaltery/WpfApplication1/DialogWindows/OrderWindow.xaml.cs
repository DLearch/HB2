﻿using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1.DialogWindows
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        int orderId;
        HomeBugaltery hb;
        bool IsEdit;

        public OrderWindow(HomeBugaltery hb, OrdersView order = null)
        {
            InitializeComponent();

            this.hb = hb;

            ComboBoxCategories.ItemsSource = hb.ListCategories.Select(c => c.Name);
            ComboBoxUsers.ItemsSource = hb.ListUsers.Select(c => c.Name);

            if (order != null)
            {
                orderId = order.Id;
                ComboBoxCategories.SelectedItem = order.CategoryName;
                ComboBoxUsers.SelectedItem = order.UserName;

                DatePickerDate.SelectedDate = order.DateOrder;
                TextBoxDescription.Text = order.Description;
                TextBoxPrice.Text = order.Price.ToString();

                Title = "Редагування операції";
                ButtonOk.Content = "Зберегти";

                IsEdit = true;
            }
            else
            {
                DatePickerDate.SelectedDate = DateTime.Now;

                Title = "Додавання операції";
                ButtonOk.Content = "Додати";

                IsEdit = false;
            }
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {

            decimal price;
            if (!decimal.TryParse(TextBoxPrice.Text, out price))
                return;

            if (IsEdit)
                hb.changeOrder(orderId, ComboBoxCategories.SelectedItem.ToString(), ComboBoxUsers.SelectedItem.ToString(), (DateTime)DatePickerDate.SelectedDate, price, TextBoxDescription.Text);
            else
                hb.addOrder(ComboBoxCategories.SelectedItem.ToString(), ComboBoxUsers.SelectedItem.ToString(), (DateTime)DatePickerDate.SelectedDate, price, TextBoxDescription.Text);

            DialogResult = true;
            Close();
        }
    }
}