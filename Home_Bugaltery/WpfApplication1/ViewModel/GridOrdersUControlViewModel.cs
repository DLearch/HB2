using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.Infrastructure;
using WpfApplication1.View;

namespace WpfApplication1.ViewModel
{
    class GridOrdersUControlViewModel : ViewModelBase
    {
        #region ListViewOrdersItemsSource

        private IEnumerable<object> _listViewOrdersItemsSource;
        public IEnumerable<object> ListViewOrdersItemsSource
        {
            get { return _listViewOrdersItemsSource; }
            set
            {
                _listViewOrdersItemsSource = value;
                OnPropertyChanged("ListViewOrdersItemsSource");
            }
        }

        #endregion

        #region ListViewOrdersSelectedItem

        private object _listViewOrdersSelectedItem;
        public object ListViewOrdersSelectedItem
        {
            get { return _listViewOrdersSelectedItem; }
            set
            {
                _listViewOrdersSelectedItem = value;
                OnPropertyChanged("ListViewOrdersSelectedItem");
            }
        }

        #endregion

        ObservableCollection<OrdersView> orders;
        HomeBugaltery _homeBugaltery;

        public HomeBugaltery HomeBugaltery
        {
            set
            {
                _homeBugaltery = value;
                ListViewOrdersItemsSource = orders = new ObservableCollection<OrdersView>();
                Update();
            }
            private get
            {
                return _homeBugaltery;
            }
        }

        public GridOrdersUControlViewModel()
        {
        }

        public void Update()
        {
            orders.Clear();
            foreach (OrdersView orderView in HomeBugaltery.ListOrders)
                orders.Add(orderView);
        }

        #region Edit Order Command

        RelayCommand _editOrderCommand;
        public System.Windows.Input.ICommand EditOrderCommand
        {
            get
            {
                if (_editOrderCommand == null)
                    _editOrderCommand = new RelayCommand(ExecuteEditOrderCommand, CanExecuteEditOrderCommand);
                return _editOrderCommand;
            }
        }

        public void ExecuteEditOrderCommand(object parameter)
        {
            OrdersView oldOrder = parameter as OrdersView;

            OrderWindow w = new OrderWindow();

            var datacontext = w.DataContext as OrderWindowViewModel;

            datacontext.Categories = HomeBugaltery.ListCategories;
            datacontext.Users = HomeBugaltery.ListUsers;
            datacontext.Order = oldOrder;

            if (ShowDialog(w) == true)
            {
                OrdersView newOrder = datacontext.Order;
                
                HomeBugaltery.changeOrder(oldOrder.Id, 
                                        newOrder.CategoryName,
                                        newOrder.UserName,
                                        newOrder.DateOrder,
                                        newOrder.Price,
                                        newOrder.Description);

                Update();
            }
        }

        public bool CanExecuteEditOrderCommand(object parameter)
        {
            return parameter != null;
        }
        #endregion

        #region Remove Order Command

        RelayCommand _removeOrderCommand;
        public System.Windows.Input.ICommand RemoveOrderCommand
        {
            get
            {
                if (_removeOrderCommand == null)
                    _removeOrderCommand = new RelayCommand(ExecuteRemoveOrderCommand, CanExecuteRemoveOrderCommand);
                return _removeOrderCommand;
            }
        }

        public void ExecuteRemoveOrderCommand(object parameter)
        {
            HomeBugaltery.deleteOrder((parameter as OrdersView).Id);
            Update();
        }

        public bool CanExecuteRemoveOrderCommand(object parameter)
        {
            return parameter != null;
        }
        #endregion
        
    }
}
