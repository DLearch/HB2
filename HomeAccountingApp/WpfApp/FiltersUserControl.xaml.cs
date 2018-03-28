using ClassLib;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for FiltersUserControl.xaml
    /// </summary>
    public partial class FiltersUserControl : UserControl
    {

        public List<Category> Categories
        {
            get
            {
                if (CheckBoxFilters.IsChecked != true || CheckBoxCategoriesFilter.IsChecked != true || filterCategories.Count == 0)
                    return null;
                return filterCategories.Where(c => c.IsSelected).Select(c => c.Category).ToList();
            }
        }

        public List<FamilyMember> FamilyMembers
        {
            get
            {
                if (CheckBoxFilters.IsChecked != true || CheckBoxFamilyMembersFilter.IsChecked != true || filterFamilyMembers.Count == 0)
                    return null;
                return filterFamilyMembers.Where(c => c.IsSelected).Select(c => c.FamilyMember).ToList();
            }
        }

        public DateTime? DateFrom
        {
            get
            {
                if (CheckBoxFilters.IsChecked != true || CheckBoxDateFilter.IsChecked != true)
                    return null;
                return DatePickerDateFilterFrom.SelectedDate;
            }
        }
        public DateTime? DateTo
        {
            get
            {
                if (CheckBoxFilters.IsChecked != true || CheckBoxDateFilter.IsChecked != true)
                    return null;
                return DatePickerDateFilterTo.SelectedDate;
            }
        }

        public decimal? PriceFrom
        {
            get
            {
                decimal price;
                if (CheckBoxFilters.IsChecked != true 
                    || CheckBoxPriceFilter.IsChecked != true 
                    || !decimal.TryParse(TextBoxPriceFilterFrom.Text, out price))
                    return null;
                return price;
            }
        }
        public decimal? PriceTo
        {
            get
            {
                decimal price;
                if (CheckBoxFilters.IsChecked != true 
                    || CheckBoxPriceFilter.IsChecked != true 
                    || !decimal.TryParse(TextBoxPriceFilterTo.Text, out price))
                    return null;
                return price;
            }
        }

        public bool? IsIncome
        {
            get
            {
                if (CheckBoxFilters.IsChecked != true || CheckBoxIsIncomeFilter.IsChecked != true)
                    return null;
                return RadioButtonIsIncome.IsChecked;
            }
        }

        HomeAccounting ha;
        ObservableCollection<FilterCategoriesItem> filterCategories;
        ObservableCollection<FilterFamilyMembersItem> filterFamilyMembers;

        public FiltersUserControl(HomeAccounting ha)
        {
            InitializeComponent();

            this.ha = ha;

            ListBoxFilterCategories.ItemsSource = filterCategories = new ObservableCollection<FilterCategoriesItem>();
            ListBoxFilterFamilyMembers.ItemsSource = filterFamilyMembers = new ObservableCollection<FilterFamilyMembersItem>();

            UpdateAll();
        }

        #region Update
        public void UpdateAll()
        {
            UpdateListBoxFilterCategories();
            UpdateListBoxFilterFamilyMembers();
        }

        public void UpdateListBoxFilterCategories()
        {
            filterCategories.Clear();
            
            foreach (var category in ha.Categories)
            {
                bool isSelected = false;

                if (ha.FilterCategories != null)
                    isSelected = ha.FilterCategories.Contains(category);

                filterCategories.Add(new FilterCategoriesItem(isSelected, category));
            }
        }

        public void UpdateListBoxFilterFamilyMembers()
        {
            filterFamilyMembers.Clear();

            foreach (var familyMember in ha.FamilyMembers)
            {
                bool isSelected = false;

                if (ha.FilterFamilyMembers != null)
                    isSelected = ha.FilterFamilyMembers.Contains(familyMember);

                filterFamilyMembers.Add(new FilterFamilyMembersItem(isSelected, familyMember));
            }
        }

        #endregion

        #region ApplyFilters

        private void ApplyFiltersCategories(object sender, EventArgs e)
        {
            ha.FilterCategories = GetFilteredListCategories();
        }

        private void ApplyFiltersFamilyMembers(object sender, EventArgs e)
        {
            ha.FilterFamilyMembers = GetFilteredListFamilyMembers();
        }

        private void ApplyFiltersDateFrom(object sender, EventArgs e)
        {
            ha.FilterDateFrom = DateFrom;
        }

        private void ApplyFiltersDateTo(object sender, EventArgs e)
        {
            ha.FilterDateTo = DateTo;
        }

        private void ApplyFiltersDate(object sender, EventArgs e)
        {
            ha.ApplyFiltersDate(DateFrom, DateTo);
        }

        private void ApplyFiltersPriceFrom(object sender, EventArgs e)
        {
            ha.FilterPriceFrom = PriceFrom;
        }

        private void ApplyFiltersPriceTo(object sender, EventArgs e)
        {
            ha.FilterPriceTo = PriceTo;
        }

        private void ApplyFiltersPrice(object sender, EventArgs e)
        {
            ha.ApplyFiltersPrice(PriceFrom, PriceTo);
        }

        private void ApplyFiltersIsIncome(object sender, EventArgs e)
        {
            ha.FilterIsIncome = IsIncome;
        }

        private void ApplyFilters(object sender, EventArgs e)
        {
            ha.ApplyFilters(
                GetFilteredListCategories(),
                GetFilteredListFamilyMembers(),
                DateFrom,
                DateTo,
                PriceFrom,
                PriceTo,
                IsIncome
            );
        }

        List<Category> GetFilteredListCategories()
        {
            return filterCategories.Where(c => c.IsSelected).Select(c => c.Category).ToList();
        }
        List<FamilyMember> GetFilteredListFamilyMembers()
        {
            return filterFamilyMembers.Where(fm => fm.IsSelected).Select(fm => fm.FamilyMember).ToList();
        }
        #endregion
    }
}
