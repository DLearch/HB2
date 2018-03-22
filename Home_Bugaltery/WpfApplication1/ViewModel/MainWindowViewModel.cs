using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WpfApplication1.Infrastructure;
using WpfApplication1.View;

namespace WpfApplication1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        #region GridOrdersUControlVisibility

        private Visibility _gridOrdersUControlVisibility;
        public Visibility GridOrdersUControlVisibility
        {
            get { return _gridOrdersUControlVisibility; }
            set
            {
                _gridOrdersUControlVisibility = value;
                OnPropertyChanged("GridOrdersUControlVisibility");
            }
        }

        #endregion

        #region GridOrdersUControlDataContext

        private object _gridOrdersUControlDataContext;
        public object GridOrdersUControlDataContext
        {
            get { return _gridOrdersUControlDataContext; }
            set
            {
                _gridOrdersUControlDataContext = value;
                OnPropertyChanged("GridOrdersUControlDataContext");
            }
        }

        #endregion

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;
        
        public MainWindowViewModel()
        {
            homeBugaltery = new HomeBugaltery();
            actHomeBogaltery = new HomeBugalteryAction();

            GridOrdersUControlDataContext = new GridOrdersUControlViewModel() { HomeBugaltery = homeBugaltery };

            ShowCommand.Execute("GridOrdersUControl");
        }


        #region Show Command

        RelayCommand _showCommand;
        public System.Windows.Input.ICommand ShowCommand
        {
            get
            {
                if (_showCommand == null)
                    _showCommand = new RelayCommand(ExecuteShowCommand);
                return _showCommand;
            }
        }

        public void ExecuteShowCommand(object parameter)
        {
            string name = parameter as string;

            if (name == "GridOrdersUControl")
            {
                GridOrdersUControlVisibility = Visibility.Visible;
            }
            else
                GridOrdersUControlVisibility = Visibility.Collapsed;
        }

        #endregion

        #region Open Window Command

        RelayCommand _openWindowCommand;
        public System.Windows.Input.ICommand OpenWindowCommand
        {
            get
            {
                if (_openWindowCommand == null)
                    _openWindowCommand = new RelayCommand(ExecuteOpenWindowCommand);
                return _openWindowCommand;
            }
        }

        public void ExecuteOpenWindowCommand(object parameter)
        {
            string name = parameter as string;

            switch (name)
            {
                case "FamilyMembers":
                    FamilyMembersWindow w = new FamilyMembersWindow();
                    (w.DataContext as FamilyMembersViewModel).HomeBugaltery = homeBugaltery;
                    ShowDialog(w);
                    break;
            }
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

        #endregion
        
    }
}
