using ClassLibrary1;
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
using System.Windows.Shapes;
using WpfApplication1.DialogWindows;
using WpfApplication1.UserControls;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HomeBugaltery hb;
        OrdersUserControl ouc;
        BalanceUserControl buc;
        ExpensesRevenuesForPeriodUserControl erfpuc;

        public MainWindow()
        {
            hb = new HomeBugaltery();

            AuthenticationWindow aw = new AuthenticationWindow(hb);

            if (aw.ShowDialog() != true)
            {
                Close();
                return;
            }

            InitializeComponent();
            
            ouc = new OrdersUserControl(hb);
            GridMain.Children.Add(ouc);

            buc = new BalanceUserControl(hb);
            GridMain.Children.Add(buc);

            erfpuc = new ExpensesRevenuesForPeriodUserControl(hb);
            GridMain.Children.Add(erfpuc);

            MoveTo(new MenuItem() { CommandParameter = "Orders"}, null);

            UpdateAll();
        }

        void UpdateAll()
        {
            ouc.UpdateAll();
            buc.UpdateAll();
            erfpuc.UpdateAll();
        }

        private void MenuItemCategories_Click(object sender, RoutedEventArgs e)
        {
            new CategoriesWindow(hb).ShowDialog();

            UpdateAll();
        }

        private void MenuItemAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (new OrderWindow(hb).ShowDialog() == true)
                UpdateAll();
        }

        void MoveTo(object sender, EventArgs e)
        {
            string param = (sender as MenuItem).CommandParameter.ToString();

            if(param == "Orders")
                ouc.Visibility = Visibility.Visible;
            else
                ouc.Visibility = Visibility.Collapsed;

            if (param == "Balance")
                buc.Visibility = Visibility.Visible;
            else
                buc.Visibility = Visibility.Collapsed;

            if (param == "Incomes" || param == "Outcomes")
            {
                erfpuc.Visibility = Visibility.Visible;
                erfpuc.IsIncome = param == "Incomes";
                erfpuc.UpdateAll();
            }
            else
                erfpuc.Visibility = Visibility.Collapsed;
        }
    }
}