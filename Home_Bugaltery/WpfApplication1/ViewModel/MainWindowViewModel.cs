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

        #region GridOrdersVisibility

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

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        ObservableCollection<OrdersView> orders;

        public MainWindowViewModel()
        {
            homeBugaltery = new HomeBugaltery();
            actHomeBogaltery = new HomeBugalteryAction();

            GridFamilyMembersVisibility = Visibility.Collapsed;
            GridOrdersVisibility = Visibility.Visible;

            DataGridOrdersItemsSource = orders = new ObservableCollection<OrdersView>();

            UpdateOrders();
        }


        private void UpdateOrders()
        {
            orders.Clear();
            foreach (OrdersView orderView in homeBugaltery.ListOrders)
                orders.Add(orderView);
        }

        #region Add Family Member Command

        RelayCommand _addFamilyMemberCommand;
        public System.Windows.Input.ICommand AddFamilyMember
        {
            get
            {
                if (_addFamilyMemberCommand == null)
                    _addFamilyMemberCommand = new RelayCommand(ExecuteAddFamilyMemberCommand, CanExecuteAddFamilyMemberCommand);
                return _addFamilyMemberCommand;
            }
        }

        public void ExecuteAddFamilyMemberCommand(object parameter)
        {
        }

        public bool CanExecuteAddFamilyMemberCommand(object parameter)
        {
            return true;
        }

        #endregion

        # region Edit Family Member Command

        RelayCommand _editFamilyMemberCommand;
        public System.Windows.Input.ICommand EditFamilyMember
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
        public System.Windows.Input.ICommand RemoveFamilyMember
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
        
        #region Move To Family Members Command

        RelayCommand _moveToFamilyMembersCommand;
        public System.Windows.Input.ICommand MoveToFamilyMembers
        {
            get
            {
                if (_moveToFamilyMembersCommand == null)
                    _moveToFamilyMembersCommand = new RelayCommand(ExecuteMoveToFamilyMembersCommand, CanExecuteMoveToFamilyMembersCommand);
                return _moveToFamilyMembersCommand;
            }
        }

        public void ExecuteMoveToFamilyMembersCommand(object parameter)
        {
            GridFamilyMembersVisibility = Visibility.Visible;
            GridOrdersVisibility = Visibility.Collapsed;
        }

        public bool CanExecuteMoveToFamilyMembersCommand(object parameter)
        {
            return true;
        }

        #endregion
        
        #region Move To Orders Command

        RelayCommand _moveToOrdersCommand;
        public System.Windows.Input.ICommand MoveToOrders
        {
            get
            {
                if (_moveToOrdersCommand == null)
                    _moveToOrdersCommand = new RelayCommand(ExecuteMoveToOrdersCommand, CanExecuteMoveToOrdersCommand);
                return _moveToOrdersCommand;
            }
        }

        public void ExecuteMoveToOrdersCommand(object parameter)
        {
            GridFamilyMembersVisibility = Visibility.Hidden;
            GridOrdersVisibility = Visibility.Visible;
        }

        public bool CanExecuteMoveToOrdersCommand(object parameter)
        {
            return true;
        }

        #endregion

        void MoveTo(string name)
        {

        }
    }
}
