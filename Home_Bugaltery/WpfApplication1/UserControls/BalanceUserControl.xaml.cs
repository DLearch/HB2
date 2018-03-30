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
    /// Interaction logic for BalanceUserControl.xaml
    /// </summary>
    public partial class BalanceUserControl : UserControl
    {
        HomeBugaltery hb;
        ObservableCollection<UserSaldo> usersSaldo;
        FilterUserControl fuc;
        public BalanceUserControl(HomeBugaltery hb)
        {
            InitializeComponent();

            this.hb = hb;

            ListBoxBalance.ItemsSource = usersSaldo = new ObservableCollection<UserSaldo>();

            fuc = new FilterUserControl(hb);
            fuc.FilterCategoriesIsEnabled = false;
            fuc.FilterUsersIsEnabled = false;
            fuc.FiltersUpdated += FilteredUsersSaldoListChanged;
            GridFilters.Children.Add(fuc);

            UpdateAll();
        }

        #region Update

        public void FilteredUsersSaldoListChanged()
        {
            UpdateListBoxBalance();
            UpdateLabelsSum();
        }
        public void UpdateAll()
        {
            fuc.UpdateAll();
            UpdateListBoxBalance();
            UpdateLabelsSum();
        }
        public void UpdateListBoxBalance()
        {
            usersSaldo.Clear();
            hb.calculateUsersSaldo(fuc.DateFromFilter, fuc.DateToFilter);
            foreach (var userSaldo in hb.UsersSaldo)
                usersSaldo.Add(userSaldo);
        }

        public void UpdateLabelsSum()
        {
            labelSaldoSum.Content = usersSaldo.Sum(us => us.Saldo).ToString("G29");
            labelDebetSum.Content = usersSaldo.Sum(us => us.Debet).ToString("G29");
            labelCreditSum.Content = usersSaldo.Sum(us => us.Credit).ToString("G29");
        }

        #endregion
    }
}
