using ClassLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {

        Order Order
        {
            get
            {
                return new Order()
                {
                    Id = orderId,
                    CategoryId = (ComboBoxCategories.SelectedItem as Category).Id,
                    FamilyMemberId = (ComboBoxFamilyMembers.SelectedItem as FamilyMember).Id,
                    Date = (DateTime)DatePickerDate.SelectedDate,
                    Description = TextBoxDescription.Text,
                    Price = decimal.Parse(TextBoxPrice.Text)
                };
            }
        }
        
        int orderId;
        HomeAccounting ha;
        bool IsEdit;

        public OrderWindow(HomeAccounting ha, Order order = null)
        {
            InitializeComponent();

            this.ha = ha;

            ComboBoxCategories.ItemsSource = ha.Categories;
            ComboBoxFamilyMembers.ItemsSource = ha.FamilyMembers;

            if (order != null)
            {
                orderId = order.Id;
                ComboBoxCategories.SelectedIndex = ha.Categories.IndexOf(ha.Categories.FirstOrDefault(c => c.Id == order.CategoryId));
                ComboBoxFamilyMembers.SelectedIndex = ha.Categories.IndexOf(ha.Categories.First(fm => fm.Id == order.FamilyMemberId));

                DatePickerDate.SelectedDate = order.Date;
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
                ha.EditOrder(Order);
            else
                ha.AddOrder(Order);

            DialogResult = true;
            Close();
        }
    }
}
