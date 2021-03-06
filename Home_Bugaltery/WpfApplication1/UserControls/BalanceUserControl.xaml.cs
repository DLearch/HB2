﻿using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public FilterUserControl FilterUserControl { get; set; }
        public BalanceUserControl(HomeBugaltery hb)
        {
            InitializeComponent();

            this.hb = hb;

            ListViewBalance.ItemsSource = usersSaldo = new ObservableCollection<UserSaldo>();

            FilterUserControl = new FilterUserControl(hb);
            FilterUserControl.FilterUsersIsEnabled = FilterUserControl.FilterCategoriesIsEnabled = false;
            FilterUserControl.FiltersUpdated += FilteredUsersSaldoListChanged;

            UpdateAll();
        }

        #region Update

        public void FilteredUsersSaldoListChanged()
        {
            UpdateListViewBalance();
            UpdateLabelsSum();
        }
        public void UpdateAll()
        {
            FilterUserControl.UpdateAll();
            UpdateListViewBalance();
            UpdateLabelsSum();
        }
        public void UpdateListViewBalance()
        {
            usersSaldo.Clear();
            hb.calculateUsersSaldo(FilterUserControl.DateFromFilter, FilterUserControl.DateToFilter);
            foreach (var userSaldo in hb.UsersSaldo)
                usersSaldo.Add(userSaldo);

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewBalance.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("UserName", ListSortDirection.Ascending));
        }

        public void UpdateLabelsSum()
        {
            LabelSaldoSum.Content = usersSaldo.Sum(us => us.Saldo).ToString("G29");
            LabelDebetSum.Content = usersSaldo.Sum(us => us.Debet).ToString("G29");
            LabelCreditSum.Content = usersSaldo.Sum(us => us.Credit).ToString("G29");
        }

        #endregion
    }
}
