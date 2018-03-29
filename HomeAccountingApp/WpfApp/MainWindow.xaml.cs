using ClassLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HomeAccounting ha;
        ObservableCollection<OrderView> ordersViews;
        FiltersUserControl fuco;

        public MainWindow()
        {
            InitializeComponent();

            ha = new HomeAccounting();
            ha.Authentication("terminator@gmail.com", "3453");
            ha.FiltersUpdated += UpdateListBoxOrders;
            ha.FiltersUpdated += UpdateLabelSum;

            ListBoxOrders.ItemsSource = ordersViews = new ObservableCollection<OrderView>();

            fuco = new FiltersUserControl(ha);
            GridFilters.Children.Add(fuco);

            UpdateAll();
        }

        #region Update

        void UpdateListBoxOrders()
        {
            ordersViews.Clear();

            foreach (var orderView in ha.FilteredOrdersViews)
                ordersViews.Add(orderView);
        }

        void UpdateAll()
        {
            UpdateListBoxOrders();
            fuco.UpdateAll();
            UpdateLabelSum();
        }

        void UpdateLabelSum()
        {
            LabelSum.Content = "Загальна сума: " + ha.GetFilteredOrdersViewsPriceSum();
        }

        #endregion

        private void MenuItemFamilyMembers_Click(object sender, RoutedEventArgs e)
        {
            FamilyMembersWindow w = new FamilyMembersWindow(ha);

            w.ShowDialog();

            UpdateAll();
        }

        private void MenuItemCategories_Click(object sender, RoutedEventArgs e)
        {
            CategoriesWindow w = new CategoriesWindow(ha);

            w.ShowDialog();

            UpdateAll();
        }

        private void MenuItemAddOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow w = new OrderWindow(ha);

            if(w.ShowDialog() == true)
                UpdateAll();
        }

        private void MenuItemEditOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow w = new OrderWindow(ha, ha.GetOrder(GetOrderViewFromSender(sender).Id));

            if (w.ShowDialog() == true)
                UpdateAll();
        }

        private void MenuItemRemoveOrder_Click(object sender, RoutedEventArgs e)
        {

            ha.RemoveOrder(GetOrderViewFromSender(sender).Id);

            UpdateAll();
        }

        OrderView GetOrderViewFromSender(object sender)
        {
            MenuItem menuItem = sender as MenuItem;
            ContextMenu contextMenu = menuItem.Parent as ContextMenu;
            ListViewItem listViewItem = contextMenu.PlacementTarget as ListViewItem;
            return listViewItem.DataContext as OrderView;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ha.SignOut();
        }
    }
}
