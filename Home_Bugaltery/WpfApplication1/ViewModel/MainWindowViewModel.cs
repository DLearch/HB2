using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.Infrastructure;
using WpfApplication1.View;

namespace WpfApplication1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        #region ListBoxFamilyMembersSelectedItem

        private object _listBoxFamilyMembersSelectedItem;
        public object ListBoxFamilyMembersSelectedItem
        {
            get { return _listBoxFamilyMembersSelectedItem; }
            set
            {
                _listBoxFamilyMembersSelectedItem = value;
                OnPropertyChanged("ListBoxFamilyMembersSelectedItem");
            }
        }

        #endregion

        #region TextBoxAddFamilyMembersText

        private string _textBoxAddFamilyMembersText;
        public string TextBoxAddFamilyMembersText
        {
            get { return _textBoxAddFamilyMembersText; }
            set
            {
                _textBoxAddFamilyMembersText = value;
                OnPropertyChanged("TextBoxAddFamilyMembersText");
            }
        }

        #endregion

        #region TextBoxEditFamilyMembersText

        private string _textBoxEditFamilyMembersText;
        public string TextBoxEditFamilyMembersText
        {
            get { return _textBoxEditFamilyMembersText; }
            set
            {
                _textBoxEditFamilyMembersText = value;
                OnPropertyChanged("TextBoxEditFamilyMembersText");
            }
        }

        #endregion

        #region ListBoxFamilyMembersItemsSource

        private IEnumerable<object> _listBoxFamilyMembersItemsSource;
        public IEnumerable<object> ListBoxFamilyMembersItemsSource
        {
            get { return _listBoxFamilyMembersItemsSource; }
            set
            {
                _listBoxFamilyMembersItemsSource = value;
                OnPropertyChanged("ListBoxFamilyMembersItemsSource");
            }
        }

        #endregion

        #region GridFamilyMembersVisibility

        private Visibility _gridFamilyMembersVisibility;
        public Visibility GridFamilyMembersVisibility
        {
            get { return _gridFamilyMembersVisibility; }
            set
            {
                _gridFamilyMembersVisibility = value;
                OnPropertyChanged("GridFamilyMembersVisibility");
            }
        }

        #endregion

        #region GridOrdersVisibility

        private Visibility _gridOrdersVisibility;
        public Visibility GridOrdersVisibility
        {
            get { return _gridOrdersVisibility; }
            set
            {
                _gridOrdersVisibility = value;
                OnPropertyChanged("GridOrdersVisibility");
            }
        }

        #endregion

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

        #region Fields

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        ObservableCollection<OrdersView> orders;
        ObservableCollection<Users> users;

        #endregion

        public MainWindowViewModel()
        {
            homeBugaltery = new HomeBugaltery();
            actHomeBogaltery = new HomeBugalteryAction();

            ListViewOrdersItemsSource = orders = new ObservableCollection<OrdersView>();
            ListBoxFamilyMembersItemsSource = users = new ObservableCollection<Users>();

            UpdateListViewOrders();
            UpdateListBoxFamilyMembers();

            MoveToCommand.Execute("GridOrders");

        }

        #region Update

        private void UpdateListViewOrders()
        {
            orders.Clear();
            foreach (OrdersView orderView in homeBugaltery.ListOrders)
                orders.Add(orderView);
        }

        private void UpdateListBoxFamilyMembers()
        {
            users.Clear();
            foreach (Users user in homeBugaltery.ListUsers)
                users.Add(user);
        }

        #endregion

        #region Add Family Member Command

        RelayCommand _addFamilyMemberCommand;
        public System.Windows.Input.ICommand AddFamilyMemberCommand
        {
            get
            {
                if (_addFamilyMemberCommand == null)
                    _addFamilyMemberCommand = new RelayCommand(ExecuteAddFamilyMemberCommand);
                return _addFamilyMemberCommand;
            }
        }

        public void ExecuteAddFamilyMemberCommand(object parameter)
        {
            UpdateListBoxFamilyMembers();
        }

        #endregion

        # region Edit Family Member Command

        RelayCommand _editFamilyMemberCommand;
        public System.Windows.Input.ICommand EditFamilyMemberCommand
        {
            get
            {
                if (_editFamilyMemberCommand == null)
                    _editFamilyMemberCommand = new RelayCommand(ExecuteEditFamilyMemberCommand, CanExecuteEditFamilyMemberCommand);
                return _editFamilyMemberCommand;
            }
        }

        public void ExecuteEditFamilyMemberCommand(object parameter)
        {
            UpdateListBoxFamilyMembers();
        }

        public bool CanExecuteEditFamilyMemberCommand(object parameter)
        {
            return ListBoxFamilyMembersSelectedItem != null;
        }

        #endregion
        
        #region Remove Family Member Command

        RelayCommand _removeFamilyMemberCommand;
        public System.Windows.Input.ICommand RemoveFamilyMemberCommand
        {
            get
            {
                if (_removeFamilyMemberCommand == null)
                    _removeFamilyMemberCommand = new RelayCommand(ExecuteRemoveFamilyMemberCommand, CanExecuteRemoveFamilyMemberCommand);
                return _removeFamilyMemberCommand;
            }
        }

        public void ExecuteRemoveFamilyMemberCommand(object parameter)
        {
            UpdateListBoxFamilyMembers();
        }

        public bool CanExecuteRemoveFamilyMemberCommand(object parameter)
        {
            return ListBoxFamilyMembersSelectedItem != null;
        }

        #endregion
        
        #region Move To Command

        RelayCommand _moveToCommand;
        public System.Windows.Input.ICommand MoveToCommand
        {
            get
            {
                if (_moveToCommand == null)
                    _moveToCommand = new RelayCommand(ExecuteMoveToCommand);
                return _moveToCommand;
            }
        }

        public void ExecuteMoveToCommand(object parameter)
        {
            string name = parameter as string;

            if (name == "GridOrders")
                GridOrdersVisibility = Visibility.Visible;
            else
                GridOrdersVisibility = Visibility.Collapsed;

            if (name == "GridFamilyMembers")
                GridFamilyMembersVisibility = Visibility.Visible;
            else
                GridFamilyMembersVisibility = Visibility.Collapsed;
        }

        #endregion

        #region Add Order Command

        RelayCommand _addOrderCommand;
        public System.Windows.Input.ICommand AddOrderCommand
        {
            get
            {
                if (_addOrderCommand == null)
                    _addOrderCommand = new RelayCommand(ExecuteAddOrderCommand);
                return _addOrderCommand;
            }
        }
        enum organiserActionEnum
        {
            addOrder = 0,

        }

        public void ExecuteAddOrderCommand(object parameter)
        {
            OrderWindow w = new OrderWindow();
            var datacontext = w.DataContext as OrderWindowViewModel;
            datacontext.Categories = homeBugaltery.ListCategories;
            datacontext.Users = homeBugaltery.ListUsers;
            //datacontext.Order = ListViewOrdersSelectedItem as OrdersView;
            if (ShowDialog(w) == true)
            {
                OrdersView order = (w.DataContext as OrderWindowViewModel).Order;
                actHomeBogaltery.SetCommand((int)organiserActionEnum.addOrder,
                                                new AddNewOrderCommand(homeBugaltery,
                                                                        order.CategoryName,
                                                                        order.UserName,
                                                                        order.DateOrder,
                                                                        order.Price,
                                                                        order.Description));
                actHomeBogaltery.DoAction((int)organiserActionEnum.addOrder);
                UpdateListViewOrders();
            }
        }

        #endregion
        
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
            OrderWindow w = new OrderWindow();
            var datacontext = w.DataContext as OrderWindowViewModel;
            datacontext.Categories = homeBugaltery.ListCategories;
            datacontext.Users = homeBugaltery.ListUsers;
            //datacontext.Order = ListViewOrdersSelectedItem as OrdersView;
            if (ShowDialog(w) == true)
            {
                // Тут должен быть код изменения 

                UpdateListViewOrders();
            }
        }

        public bool CanExecuteEditOrderCommand(object parameter)
        {
            return false;
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
        }

        public bool CanExecuteRemoveOrderCommand(object parameter)
        {
            return false;
        }
        #endregion
    }
}
