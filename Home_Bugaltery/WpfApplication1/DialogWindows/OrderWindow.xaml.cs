using ClassLibrary1;
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
            if (!CheckFields())
                return;

            if (IsEdit)
                hb.changeOrder(
                    orderId, 
                    ComboBoxCategories.SelectedItem.ToString(), 
                    ComboBoxUsers.SelectedItem.ToString(), 
                    (DateTime)DatePickerDate.SelectedDate, 
                    decimal.Parse(TextBoxPrice.Text), 
                    TextBoxDescription.Text
                );
            else
                hb.addOrder(
                    ComboBoxCategories.SelectedItem.ToString(), 
                    ComboBoxUsers.SelectedItem.ToString(), 
                    (DateTime)DatePickerDate.SelectedDate,
                    decimal.Parse(TextBoxPrice.Text), 
                    TextBoxDescription.Text
                );

            DialogResult = true;
            Close();
        }

        bool CheckFields()
        {
            bool result = true;

            if (ComboBoxCategories.SelectedItem == null)
            {
                TextBlockCategoriesError.Text = "Виберіть категорію!";
                ComboBoxCategories.BorderBrush = Brushes.Red;
                result = false;
            }
            if (ComboBoxUsers.SelectedItem == null)
            {
                TextBlockUsersError.Text = "Виберіть користувача!";
                ComboBoxUsers.BorderBrush = Brushes.Red;
                result = false;
            }
            if (DatePickerDate.SelectedDate == null)
            {
                TextBlockDateError.Text = "Виберіть дату!";
                DatePickerDate.BorderBrush = Brushes.Red;
                result = false;
            }
            decimal price;
            if (!decimal.TryParse(TextBoxPrice.Text, out price))
            {
                TextBlockPriceError.Text = "Помилка!";
                TextBoxPrice.BorderBrush = Brushes.Red;
                result = false;
            }
            if (string.IsNullOrEmpty(TextBoxPrice.Text))
            {
                TextBlockPriceError.Text = "Введіть ціну!";
                TextBoxPrice.BorderBrush = Brushes.Red;
                result = false;
            }

            return result;
        }

        private void ComboBoxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlockCategoriesError.Text = string.Empty;
            ComboBoxCategories.BorderBrush = Brushes.LightGray;
        }

        private void ComboBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlockUsersError.Text = string.Empty;
            ComboBoxUsers.BorderBrush = Brushes.LightGray;
        }

        private void DatePickerDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlockDateError.Text = string.Empty;
            DatePickerDate.BorderBrush = Brushes.LightGray;
        }

        private void TextBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockPriceError.Text = string.Empty;
            TextBoxPrice.BorderBrush = Brushes.LightGray;
        }

        private void TextBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockDescriptionError.Text = string.Empty;
            TextBoxDescription.BorderBrush = Brushes.LightGray;
        }
    }
}
