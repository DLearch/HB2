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

        void UpdateGridOrdersUControl()
        {
            (GridOrdersUControlDataContext as GridOrdersUControlViewModel).Update();
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
            Window window;

            switch (name)
            {
                case "FamilyMembers":
                    window = new FamilyMembersWindow();
                    (window.DataContext as FamilyMembersViewModel).HomeBugaltery = homeBugaltery;
                    break;
                case "Categories":
                    window = new CategoriesWindow();
                    (window.DataContext as CategoriesWindowViewModel).HomeBugaltery = homeBugaltery;
                    break;
                case "AddOrder":
                    window = new OrderWindow();
                    OrderWindowViewModel dc = window.DataContext as OrderWindowViewModel;
                    dc.HomeBugaltery = homeBugaltery;
                    dc.Mode = OrderWindowMode.Add;

                    break;
                default:
                    return;
            }

            ShowDialog(window);

            UpdateGridOrdersUControl();
        }

        #endregion
        
    }
}
