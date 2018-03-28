using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Infrastructure;

namespace WpfApplication1.ViewModel
{
    class ExpensesRevenuesForPeriodViewModel : ViewModelBase
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
            foreach (OrdersView orderView in HomeBugaltery.FilteredListOrders)
                orders.Add(orderView);

        }

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
}
