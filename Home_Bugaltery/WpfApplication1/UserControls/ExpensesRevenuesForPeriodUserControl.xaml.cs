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
        FilterUserControl fuc;

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
                {
                    ct = "Загальна сумма доходів: ";
                    labelName.Content = "Доходи за період: ";
                }
                else
                {
                    ct = "Загальна сума витрат: ";
                    labelName.Content = "Витрати за період: ";
                }
                UpdateAll();
            }
        }

        public ExpensesRevenuesForPeriodUserControl(HomeBugaltery hb, bool isIncome = true)
        {
            InitializeComponent();

            this.hb = hb;

            ListBoxOrders.ItemsSource = orders = new ObservableCollection<OrdersView>();

            fuc = new FilterUserControl(hb);
            fuc.FilterCategoriesIsEnabled = false;
            fuc.FilterUsersIsEnabled = false;
            fuc.FiltersUpdated += FilteredUsersSaldoListChanged;
            GridFilters.Children.Add(fuc);
            
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
            fuc.UpdateAll();
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
            labelSum.Content = ct + hb.applyFiltersForExpensRevenues(IsIncome, fuc.DateFromFilter, fuc.DateToFilter).ToString("G29");
        }

        #endregion
    }
}
