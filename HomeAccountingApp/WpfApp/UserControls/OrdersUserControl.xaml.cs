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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for OrdersUserControl.xaml
    /// </summary>
    public partial class OrdersUserControl : UserControl
    {

        HomeAccounting ha;
        ObservableCollection<OrderView> ordersViews;
        FiltersUserControl fuco;

        public OrdersUserControl(HomeAccounting ha)
        {
            InitializeComponent();

            this.ha = ha;

            ListBoxOrders.ItemsSource = ordersViews = new ObservableCollection<OrderView>();

            fuco = new FiltersUserControl(ha);
            GridFilters.Children.Add(fuco);

            ha.FiltersUpdated += UpdateListBoxOrders;
            ha.FiltersUpdated += UpdateLabelSum;
        }

        #region Update

        public void UpdateListBoxOrders()
        {
            ordersViews.Clear();

            foreach (var orderView in ha.FilteredOrdersViews)
                ordersViews.Add(orderView);
        }

        public void UpdateAll()
        {
            UpdateListBoxOrders();
            fuco.UpdateAll();
            UpdateLabelSum();
        }

        public void UpdateLabelSum()
        {
            LabelSum.Content = "Загальна сума: " + ha.GetFilteredOrdersViewsPriceSum();
        }

        #endregion

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
        private void MenuItemUpdateOrders_Click(object sender, RoutedEventArgs e)
        {
            UpdateAll();
        }

        OrderView GetOrderViewFromSender(object sender)
        {
            MenuItem menuItem = sender as MenuItem;
            ContextMenu contextMenu = menuItem.Parent as ContextMenu;
            ListViewItem listViewItem = contextMenu.PlacementTarget as ListViewItem;
            return listViewItem.DataContext as OrderView;
        }
    }
}
