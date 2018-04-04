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

namespace WpfApplication1.UserControls
{
    /// <summary>
    /// Interaction logic for ExpensesRevenuesForPeriodUserControl.xaml
    /// </summary>
    public partial class ExpensesRevenuesForPeriodUserControl : UserControl
    {
        string ct;
        HomeBugaltery hb;
        ObservableCollection<OrdersView> orders;
        public FilterUserControl FilterUserControlIncomes { get; set; }
        public FilterUserControl FilterUserControlOutcomes { get; set; }

        bool isIncome;
        public bool IsIncome
        {
            get
            {
                return isIncome;
            }
            set
            {
                isIncome = value;
                if (value)
                    ct = "Загальна сумма доходів: ";
                else
                    ct = "Загальна сума витрат: ";
                UpdateAll();
            }
        }

        public ExpensesRevenuesForPeriodUserControl(HomeBugaltery hb, bool isIncome = true)
        {
            InitializeComponent();

            this.hb = hb;

            ListBoxOrders.ItemsSource = orders = new ObservableCollection<OrdersView>();

            FilterUserControlIncomes = new FilterUserControl(hb);
            FilterUserControlIncomes.FilterUsersIsEnabled = FilterUserControlIncomes.FilterCategoriesIsEnabled = false;
            FilterUserControlIncomes.FiltersUpdated += FilteredUsersSaldoListChanged;

            FilterUserControlOutcomes = new FilterUserControl(hb);
            FilterUserControlOutcomes.FilterUsersIsEnabled = FilterUserControlOutcomes.FilterCategoriesIsEnabled = false;
            FilterUserControlOutcomes.FiltersUpdated += FilteredUsersSaldoListChanged;

            IsIncome = isIncome;

            UpdateAll();
        }

        #region Update

        public void FilteredUsersSaldoListChanged()
        {
            UpdateLabelSum();
            UpdateListBoxOrder();
        }
        public void UpdateAll()
        {
            FilterUserControlIncomes.UpdateAll();
            FilterUserControlOutcomes.UpdateAll();
            UpdateLabelSum();
            UpdateListBoxOrder();
        }
        public void UpdateListBoxOrder()
        {
            orders.Clear();
            foreach (var order in hb.FilterOrderExpensRevenues)
                orders.Add(order);
        }

        public void UpdateLabelSum()
        {
            DateTime? from;
            DateTime? to;

            if (IsIncome)
            {
                from = FilterUserControlIncomes.DateFromFilter;
                to = FilterUserControlIncomes.DateToFilter;
            }
            else
            {
                from = FilterUserControlOutcomes.DateFromFilter;
                to = FilterUserControlOutcomes.DateToFilter;
            }
            
            LabelSum.Content = ct + hb.applyFiltersForExpensRevenues(IsIncome, from, to).ToString("G29");
        }

        #endregion
    }
}
