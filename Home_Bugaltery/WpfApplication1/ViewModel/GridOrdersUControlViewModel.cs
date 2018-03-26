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

        #region ListBoxCategoriesFiltersItemsSource

        private IEnumerable<object> _listBoxCategoriesFiltersItemsSource;
        public IEnumerable<object> ListBoxCategoriesFiltersItemsSource
        {
            get { return _listBoxCategoriesFiltersItemsSource; }
            set
            {
                _listBoxCategoriesFiltersItemsSource = value;
                OnPropertyChanged("ListBoxCategoriesFiltersItemsSource");
            }
        }

        #endregion

        #region CheckBoxCategoriesFilterIsChecked

        private bool? _checkBoxCategoriesFilterIsChecked;
        public bool? CheckBoxCategoriesFilterIsChecked
        {
            get { return _checkBoxCategoriesFilterIsChecked; }
            set
            {
                _checkBoxCategoriesFilterIsChecked = value;
                OnPropertyChanged("CheckBoxCategoriesFilterIsChecked");
            }
        }

        #endregion

        #region CheckBoxDateFilterIsChecked

        private bool? _checkBoxDateFilterIsChecked;
        public bool? CheckBoxDateFilterIsChecked
        {
            get { return _checkBoxDateFilterIsChecked; }
            set
            {
                _checkBoxDateFilterIsChecked = value;
                OnPropertyChanged("CheckBoxDateFilterIsChecked");
            }
        }

        #endregion

        #region DatePickerDateFromSelectedDate

        private DateTime? _datePickerDateFromSelectedDate;
        public DateTime? DatePickerDateFromSelectedDate
        {
            get { return _datePickerDateFromSelectedDate; }
            set
            {
                _datePickerDateFromSelectedDate = value;
                OnPropertyChanged("DatePickerDateFromSelectedDate");
            }
        }

        #endregion
        
        #region DatePickerDateToSelectedDate

        private DateTime? _datePickerDateToSelectedDate;
        public DateTime? DatePickerDateToSelectedDate
        {
            get { return _datePickerDateToSelectedDate; }
            set
            {
                _datePickerDateToSelectedDate = value;
                OnPropertyChanged("DatePickerDateToSelectedDate");
            }
        }

        #endregion

        #region CheckBoxFiltersIsChecked

        private bool? _checkBoxFiltersIsChecked;
        public bool? CheckBoxFiltersIsChecked
        {
            get { return _checkBoxFiltersIsChecked; }
            set
            {
                _checkBoxFiltersIsChecked = value;
                OnPropertyChanged("CheckBoxFiltersIsChecked");
            }
        }

        #endregion

        #region HomeBugaltery

        HomeBugaltery _homeBugaltery;
        public HomeBugaltery HomeBugaltery
        {
            set
            {
                _homeBugaltery = value;
                ListViewOrdersItemsSource = orders = new ObservableCollection<OrdersView>();
                ListBoxCategoriesFiltersItemsSource = filterCategories = new ObservableCollection<FilterCategoriesItem>();
                CheckBoxCategoriesFilterIsChecked = CheckBoxFiltersIsChecked = CheckBoxDateFilterIsChecked = false;
                Update();
            }
            private get
            {
                return _homeBugaltery;
            }
        }

        #endregion 

        ObservableCollection<OrdersView> orders;
        ObservableCollection<FilterCategoriesItem> filterCategories;

        public void Update()
        {
            ObservableCollection<FilterCategoriesItem> tmp = new ObservableCollection<FilterCategoriesItem>();

            foreach (var item in HomeBugaltery.ListCategories)
                tmp.Add(filterCategories.DefaultIfEmpty(new FilterCategoriesItem(false, item)).FirstOrDefault(c => c.Category == item));

            ListBoxCategoriesFiltersItemsSource = filterCategories = tmp;
            
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
            OrderWindow window = new OrderWindow();
            OrderWindowViewModel dc = window.DataContext as OrderWindowViewModel;
            dc.HomeBugaltery = HomeBugaltery;
            dc.Mode = OrderWindowMode.Edit;
            dc.Order = parameter as OrdersView;

            if(ShowDialog(window) == true)
                Update();
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
        
        #region Apply Filters Command

        RelayCommand _applyFiltersCommand;
        public System.Windows.Input.ICommand ApplyFiltersCommand
        {
            get
            {
                if (_applyFiltersCommand == null)
                    _applyFiltersCommand = new RelayCommand(ExecuteApplyFiltersCommand);
                return _applyFiltersCommand;
            }
        }

        public void ExecuteApplyFiltersCommand(object parameter)
        {
            HomeBugaltery.ClearOrdersFilters();

            List<string> categoriesList = null;
            DateTime? dateFrom = null;
            DateTime? dateTo = null;

            if (CheckBoxFiltersIsChecked == true)
            {
                if (CheckBoxCategoriesFilterIsChecked == true)
                    categoriesList = filterCategories.Where(f => f.IsSelected).Select(f => f.Category.Name).ToList();

                if (CheckBoxDateFilterIsChecked == true)
                {
                    dateFrom = DatePickerDateFromSelectedDate;
                    dateTo = DatePickerDateToSelectedDate;
                }
            }

            HomeBugaltery.aplyOrdersFilters(
                categoriesList,
                null,
                dateFrom,
                dateTo
            );

            Update();
        }
        #endregion
    }

    class FilterCategoriesItem
    {
        public bool IsSelected { get; set; }

        public Categories Category { get; set; }

        public FilterCategoriesItem(bool isSelected, Categories category)
        {
            IsSelected = isSelected;
            Category = category;
        }
    }
}
