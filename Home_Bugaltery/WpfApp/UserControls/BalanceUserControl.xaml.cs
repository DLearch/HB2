using System;
using System.Collections.Generic;
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
    /// Interaction logic for BalanceUserControl.xaml
    /// </summary>
    public partial class BalanceUserControl : UserControl
    {
        HomeAccounting ha;
        FiltersUserControl fuc;
        public BalanceUserControl(HomeAccounting ha)
        {
            InitializeComponent();

            this.ha = ha;

            fuc = new FiltersUserControl(ha);
            GridFilters.Children.Add(fuc);

            ha.FiltersUpdated += UpdateListBoxBalance;
        }

        #region Update

        void UpdateAll()
        {
            fuc.UpdateAll();
        }
        void UpdateListBoxBalance()
        {
            
        }

        #endregion
    }
}
