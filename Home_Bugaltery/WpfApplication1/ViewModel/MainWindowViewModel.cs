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

        #region DataGridOrdersItemsSource

        private IEnumerable<object> _dataGridOrdersItemsSource;
        public IEnumerable<object> DataGridOrdersItemsSource
        {
            get { return _dataGridOrdersItemsSource; }
            set
            {
                _dataGridOrdersItemsSource = value;
                OnPropertyChanged("DataGridOrdersItemsSource");
            }
        }

        #endregion

        #region DataGridOrdersSelectedItem

        private IEnumerable<object> _dataGridOrdersSelectedItem;
        public IEnumerable<object> DataGridOrdersSelectedItem
        {
            get { return _dataGridOrdersSelectedItem; }
            set
            {
                _dataGridOrdersSelectedItem = value;
                OnPropertyChanged("DataGridOrdersSelectedItem");
            }
        }

        #endregion

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        ObservableCollection<OrdersView> orders;
        ObservableCollection<Users> users;

        public MainWindowViewModel()
        {
            homeBugaltery = new HomeBugaltery();
            actHomeBogaltery = new HomeBugalteryAction();

            DataGridOrdersItemsSource = orders = new ObservableCollection<OrdersView>();
            ListBoxFamilyMembersItemsSource = users = new ObservableCollection<Users>();

            UpdateDataGridOrders();
            UpdateListBoxFamilyMembers();

            MoveToCommand.Execute("GridOrders");

        }


        private void UpdateDataGridOrders()
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
            if(ShowDialog(w) == true)
            {
                OrdersView order = (w.DataContext as OrderWindowViewModel).Order;
                actHomeBogaltery.SetCommand((int)organiserActionEnum.addOrder,
                                                new AddNewOrderCommand( homeBugaltery, 
                                                                        order.CategoryName, 
                                                                        order.UserName,
                                                                        order.DateOrder, 
                                                                        order.Price,
                                                                        order.Description));
                actHomeBogaltery.DoAction((int)organiserActionEnum.addOrder);
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
            (w.DataContext as OrderWindowViewModel).Order = DataGridOrdersSelectedItem as OrdersView;
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
            }
        }

        public bool CanExecuteEditOrderCommand(object parameter)
        {
            return DataGridOrdersSelectedItem != null;
        }
        #endregion
    }
}
