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
using WpfApp2.FilterItems;

namespace WpfApplication1.UserControls
{
    /// <summary>
    /// Interaction logic for FilterUserControl.xaml
    /// </summary>
    public partial class FilterUserControl : UserControl
    {
        #region Properties

        //public decimal? PriceFrom
        //{
        //    get
        //    {
        //        decimal price;
        //        if (CheckBoxFilters.IsChecked != true
        //            || !FilterPriceIsEnabled
        //            || CheckBoxPriceFilter.IsChecked != true 
        //            || !decimal.TryParse(TextBoxPriceFilterFrom.Text, out price))
        //            return null;
        //        return price;
        //    }
        //}
        //public decimal? PriceTo
        //{
        //    get
        //    {
        //        decimal price;
        //        if (CheckBoxFilters.IsChecked != true
        //            || !FilterPriceIsEnabled
        //            || CheckBoxPriceFilter.IsChecked != true 
        //            || !decimal.TryParse(TextBoxPriceFilterTo.Text, out price))
        //            return null;
        //        return price;
        //    }
        //}

        //public bool? IsIncome
        //{
        //    get
        //    {
        //        if (CheckBoxFilters.IsChecked != true || !FilterIsIncomeIsEnabled || CheckBoxIsIncomeFilter.IsChecked != true)
        //            return null;
        //        return RadioButtonIsIncome.IsChecked;
        //    }
        //}

        #endregion

        #region FiltersIsEnubled Properties

        public bool FilterCategoriesIsEnabled
        {
            get
            {
                return GroupBoxCategoriesFilter.IsEnabled;
            }
            set
            {
                GroupBoxCategoriesFilter.IsEnabled = value;
                if (value)
                    GroupBoxCategoriesFilter.Visibility = Visibility.Visible;
                else
                    GroupBoxCategoriesFilter.Visibility = Visibility.Collapsed;
                ApplyFilters(null, null);
            }
        }

        public bool FilterUsersIsEnabled
        {
            get
            {
                return GroupBoxUsersFilter.IsEnabled;
            }
            set
            {
                GroupBoxUsersFilter.IsEnabled = value;
                if (value)
                    GroupBoxUsersFilter.Visibility = Visibility.Visible;
                else
                    GroupBoxUsersFilter.Visibility = Visibility.Collapsed;
                ApplyFilters(null, null);
            }
        }

        public bool FilterDateIsEnabled
        {
            get
            {
                return GroupBoxDateFilter.IsEnabled;
            }
            set
            {
                GroupBoxDateFilter.IsEnabled = value;
                if (value)
                    GroupBoxDateFilter.Visibility = Visibility.Visible;
                else
                    GroupBoxDateFilter.Visibility = Visibility.Collapsed;
                ApplyFilters(null, null);
            }
        }

        /*public*/ bool FilterPriceIsEnabled
        {
            get
            {
                return GroupBoxPriceFilter.IsEnabled;
            }
            set
            {
                GroupBoxPriceFilter.IsEnabled = value;
                if (value)
                    GroupBoxPriceFilter.Visibility = Visibility.Visible;
                else
                    GroupBoxPriceFilter.Visibility = Visibility.Collapsed;
                ApplyFilters(null, null);
            }
        }

        /*public*/ bool FilterIsIncomeIsEnabled
        {
            get
            {
                return GroupBoxIsIncomeFilter.IsEnabled;
            }
            set
            {
                GroupBoxIsIncomeFilter.IsEnabled = value;
                if (value)
                    GroupBoxIsIncomeFilter.Visibility = Visibility.Visible;
                else
                    GroupBoxIsIncomeFilter.Visibility = Visibility.Collapsed;
                ApplyFilters(null, null);
            }
        }

        #endregion

        public event Action FiltersUpdated;
        HomeBugaltery homeBugaltery;
        ObservableCollection<FilterCategoriesItem> filterCategories;
        ObservableCollection<FilterUsersItem> filterUsers;

        public FilterUserControl(HomeBugaltery homeBugaltery)
        {
            InitializeComponent();

            this.homeBugaltery = homeBugaltery;

            FilterPriceIsEnabled = false;
            FilterIsIncomeIsEnabled = false;
            
            ListBoxFilterCategories.ItemsSource = filterCategories = new ObservableCollection<FilterCategoriesItem>();
            ListBoxFilterUsers.ItemsSource = filterUsers = new ObservableCollection<FilterUsersItem>();

            ApplyFilters(null, null);
        }

        #region Update

        public void UpdateAll()
        {
            UpdateListBoxFilterCategories();
            UpdateListBoxFilterUsers();
        }

        public void UpdateListBoxFilterCategories()
        {
            ObservableCollection<FilterCategoriesItem> tmp = new ObservableCollection<FilterCategoriesItem>();

            foreach (var item in homeBugaltery.ListCategories)
                tmp.Add(filterCategories.DefaultIfEmpty(new FilterCategoriesItem(false, item)).FirstOrDefault(c => c.Category == item));

            filterCategories.Clear();

            ListBoxFilterCategories.ItemsSource = filterCategories = tmp;
        }

        public void UpdateListBoxFilterUsers()
        {
            ObservableCollection<FilterUsersItem> tmp = new ObservableCollection<FilterUsersItem>();

            foreach (var user in homeBugaltery.ListUsers)
                tmp.Add(filterUsers.DefaultIfEmpty(new FilterUsersItem(false, user)).FirstOrDefault(c => c.User == user));

            filterUsers.Clear();

            ListBoxFilterUsers.ItemsSource = filterUsers = tmp;
        }

        #endregion

        private void ApplyFilters(object sender, EventArgs e)
        {
            List<string> categoriesList = null;
            List<string> usersList = null;
            DateTime? dateFrom = null;
            DateTime? dateTo = null;

            if (CheckBoxFilters.IsChecked == true)
            {
                if (CheckBoxCategoriesFilter.IsChecked == true)
                    categoriesList = filterCategories.Where(c => c.IsSelected).Select(c => c.Category.Name).ToList();

                if (categoriesList != null && categoriesList.Count == 0)
                    categoriesList = null;

                if (CheckBoxUsersFilter.IsChecked == true)
                    usersList = filterUsers.Where(c => c.IsSelected).Select(c => c.User.Name).ToList();

                if (usersList != null && usersList.Count == 0)
                    usersList = null;

                if (CheckBoxDateFilter.IsChecked == true)
                {
                    dateFrom = DatePickerDateFilterFrom.SelectedDate;
                    dateTo = DatePickerDateFilterTo.SelectedDate;
                }
            }

            homeBugaltery.aplyOrdersFilters(
                categoriesList,
                usersList,
                dateFrom,
                dateTo
            );

            FiltersUpdated?.Invoke();
        }
    }
}
