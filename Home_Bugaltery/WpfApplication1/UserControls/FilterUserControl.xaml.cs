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
        #region Filters Data Properties

        public List<string> CategoriesFilterList
        {
            get
            {
                List<string> categoriesList = null;

                if (FilterCategoriesIsEnabled && CheckBoxCategoriesFilter.IsChecked == true)
                    categoriesList = filterCategories.Where(c => c.IsSelected).Select(c => c.Category.Name).ToList();

                if (categoriesList != null && categoriesList.Count == 0)
                    categoriesList = null;

                return categoriesList;
            }
        }

        public List<string> UsersFilterList
        {
            get
            {
                List<string> usersList = null;

                if (FilterUsersIsEnabled && CheckBoxUsersFilter.IsChecked == true)
                    usersList = filterUsers.Where(c => c.IsSelected).Select(c => c.User.Name).ToList();

                if (usersList != null && usersList.Count == 0)
                    usersList = null;

                return usersList;
            }
        }

        public DateTime? DateFromFilter
        {
            get
            {
                if (FilterDateIsEnabled && CheckBoxDateFilter.IsChecked == true)
                    return DatePickerDateFilterFrom.SelectedDate;

                return null;
            }
        }
        public DateTime? DateToFilter
        {
            get
            {
                if (FilterDateIsEnabled && CheckBoxDateFilter.IsChecked == true)
                    return DatePickerDateFilterTo.SelectedDate;

                return null;
            }
        }
        
        #endregion

        #region FilterIsEnabled

        public bool FilterCategoriesIsEnabled
        {
            get
            {
                return GroupBoxCategoriesFilter.IsEnabled;
            }
            set
            {
                ChangeFilterStatus(GroupBoxCategoriesFilter, value);
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
                ChangeFilterStatus(GroupBoxUsersFilter, value);
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
                ChangeFilterStatus(GroupBoxDateFilter, value);
            }
        }
        
        void ChangeFilterStatus(Control c, bool s)
        {
            c.IsEnabled = s;
            if (s)
                c.Visibility = Visibility.Visible;
            else
                c.Visibility = Visibility.Collapsed;

            FiltersUpdated?.Invoke();
        }

        #endregion

        #region Конструктор, поля
        
        public event Action FiltersUpdated;

        HomeBugaltery hb;
        ObservableCollection<FilterCategoriesItem> filterCategories;
        ObservableCollection<FilterUsersItem> filterUsers;

        public FilterUserControl(HomeBugaltery hb)
        {
            InitializeComponent();

            this.hb = hb;

            ListBoxFilterCategories.ItemsSource = filterCategories = new ObservableCollection<FilterCategoriesItem>();
            ListBoxFilterUsers.ItemsSource = filterUsers = new ObservableCollection<FilterUsersItem>();

            UpdateAll();
        }

        #endregion

        #region Update

        public void UpdateAll()
        {
            UpdateListBoxFilterCategories();
            UpdateListBoxFilterUsers();
            FiltersUpdated?.Invoke();
        }

        public void UpdateListBoxFilterCategories()
        {
            ObservableCollection<FilterCategoriesItem> tmp = new ObservableCollection<FilterCategoriesItem>();

            foreach (var item in hb.ListCategories)
                tmp.Add(filterCategories.DefaultIfEmpty(new FilterCategoriesItem(false, item)).FirstOrDefault(c => c.Category == item));

            filterCategories.Clear();

            ListBoxFilterCategories.ItemsSource = filterCategories = tmp;
        }

        public void UpdateListBoxFilterUsers()
        {
            ObservableCollection<FilterUsersItem> tmp = new ObservableCollection<FilterUsersItem>();

            foreach (var user in hb.ListUsers)
                tmp.Add(filterUsers.DefaultIfEmpty(new FilterUsersItem(false, user)).FirstOrDefault(c => c.User == user));

            filterUsers.Clear();

            ListBoxFilterUsers.ItemsSource = filterUsers = tmp;
        }

        #endregion
        
        private void ButtonFilters_Click(object sender, RoutedEventArgs e)
        {
            FiltersUpdated?.Invoke();
        }
    }
}
