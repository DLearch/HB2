using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        #region Конструктор, поля и свойства
        
        public FilterUserControl FilterUserControl { get; set; }

        HomeBugaltery hb;
        ObservableCollection<OrdersView> ordersViews;

        public OrdersUserControl(HomeBugaltery hb)
        {
            InitializeComponent();

            this.hb = hb;

            ButtonEdit.IsEnabled = ButtonRemove.IsEnabled = false;

            ListViewOrders.ItemsSource = ordersViews = new ObservableCollection<OrdersView>();

            FilterUserControl = new FilterUserControl(hb);
            FilterUserControl.FiltersUpdated += FilteredOrdersListChanged;

        }

        #endregion

        #region Update

        public void FilteredOrdersListChanged()
        {
            hb.aplyOrdersFilters(
                FilterUserControl.CategoriesFilterList, 
                FilterUserControl.UsersFilterList, 
                FilterUserControl.DateFromFilter, 
                FilterUserControl.DateToFilter
                );

            UpdateListBoxOrders();
            UpdateLabelSum();
        }

        public void UpdateListBoxOrders()
        {
            ordersViews.Clear();
            
            foreach (var orderView in hb.FilteredListOrders)
                ordersViews.Add(orderView);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewOrders.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("DateOrder", ListSortDirection.Ascending));
        }

        public void UpdateAll()
        {
            FilterUserControl.UpdateAll();
            UpdateListBoxOrders();
            UpdateLabelSum();
        }

        public void UpdateLabelSum()
        {
            LabelSum.Content = "Загальна сума: " + ordersViews.Sum(ov => (hb.ListCategories.First(c => c.Name == ov.CategoryName).Type) ? ov.Price : ov.Price * -1 ).ToString("G29"); ;
        }

        #endregion
        
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow w = new OrderWindow(hb);

            if (w.ShowDialog() == true)
                UpdateAll();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow w = new OrderWindow(hb, hb.ListOrders.First(o => o.Id == ordersViews[ListViewOrders.SelectedIndex].Id));

            if (w.ShowDialog() == true)
                UpdateAll();
        }
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            hb.deleteOrder(ordersViews[ListViewOrders.SelectedIndex].Id);

            UpdateAll();
        }

        private void ListBoxOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonEdit.IsEnabled = ButtonRemove.IsEnabled = ListViewOrders.SelectedItem != null;
        }
    }
}