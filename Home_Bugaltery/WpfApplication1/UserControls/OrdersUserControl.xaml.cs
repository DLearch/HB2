using ClassLibrary1;
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
using WpfApplication1.DialogWindows;

namespace WpfApplication1.UserControls
{
    /// <summary>
    /// Interaction logic for OrdersUserControl.xaml
    /// </summary>
    public partial class OrdersUserControl : UserControl
    {
        HomeBugaltery hb;
        ObservableCollection<OrdersView> ordersViews;
        FilterUserControl fuco;

        public OrdersUserControl(HomeBugaltery hb)
        {
            InitializeComponent();

            this.hb = hb;

            ListBoxOrders.ItemsSource = ordersViews = new ObservableCollection<OrdersView>();

            fuco = new FilterUserControl(hb);
            fuco.FiltersUpdated += UpdateAll;
            GridFilters.Children.Add(fuco);
            
        }

        #region Update

        public void UpdateListBoxOrders()
        {
            ordersViews.Clear();
            
            foreach (var orderView in hb.FilteredListOrders)
                ordersViews.Add(orderView);
        }

        public void UpdateAll()
        {
            fuco.UpdateAll();
            UpdateListBoxOrders();
            UpdateLabelSum();
        }

        public void UpdateLabelSum()
        {
            //LabelSum.Content = "Загальна сума: " + ha.GetFilteredOrdersViewsPriceSum();
        }

        #endregion

        private void MenuItemEditOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow w = new OrderWindow(hb, hb.ListOrders.First(o => o.Id == GetOrderViewFromSender(sender).Id));

            if (w.ShowDialog() == true)
                UpdateAll();
        }

        private void MenuItemRemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            hb.deleteOrder(GetOrderViewFromSender(sender).Id);

            UpdateAll();
        }
        private void MenuItemUpdateOrders_Click(object sender, RoutedEventArgs e)
        {
            UpdateAll();
        }

        OrdersView GetOrderViewFromSender(object sender)
        {
            MenuItem menuItem = sender as MenuItem;
            ContextMenu contextMenu = menuItem.Parent as ContextMenu;
            ListViewItem listViewItem = contextMenu.PlacementTarget as ListViewItem;
            return listViewItem.DataContext as OrdersView;
        }
    }
}
