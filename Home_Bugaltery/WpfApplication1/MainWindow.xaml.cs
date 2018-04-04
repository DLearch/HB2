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
        HomeBugaltery hb = HomeBugaltery.getInstance();
        OrdersUserControl ouc;
        BalanceUserControl buc;
        ExpensesRevenuesForPeriodUserControl erfpuc;
        Users user;

        UserControl curUserControl;

        public MainWindow()
        {
            AuthenticationWindow aw = new AuthenticationWindow(hb);

            if (aw.ShowDialog() != true)
            {
                Close();
                return;
            }

            user = aw.User;

            Title = "Домашня бугалтерія - " + user.Name;

            InitializeComponent();

            curUserControl = ouc = new OrdersUserControl(hb);
            GridMain.Children.Add(ouc);

            buc = new BalanceUserControl(hb);
            GridMain.Children.Add(buc);
            buc.Visibility = Visibility.Collapsed;

            erfpuc = new ExpensesRevenuesForPeriodUserControl(hb);
            GridMain.Children.Add(erfpuc);
            erfpuc.Visibility = Visibility.Collapsed;


            MoveTo(new Button() { CommandParameter = "Orders"}, null);

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

        private void MenuItemUsers_Click(object sender, RoutedEventArgs e)
        {
            new UsersWindow(hb, user).ShowDialog();

            UpdateAll();
        }

        void MoveTo(object sender, EventArgs e)
        {
            string param = (sender as Button).CommandParameter.ToString();

            curUserControl.Visibility = Visibility.Collapsed;

            if(param == "Orders")
                curUserControl = ouc;
            if (param == "Balance")
                curUserControl = buc;

            if (param == "Incomes" || param == "Outcomes")
            {
                curUserControl = erfpuc;
                erfpuc.IsIncome = param == "Incomes";
                erfpuc.UpdateAll();
            }

            curUserControl.Visibility = Visibility.Visible;
        }

        private void ButtonFilters_Click(object sender, RoutedEventArgs e)
        {
            bool result;

            if (ouc == curUserControl)
            {
                result = ouc.FiltersIsVisible = !ouc.FiltersIsVisible;
            }
            else if (buc == curUserControl)
            {
                result = buc.FiltersIsVisible = !buc.FiltersIsVisible;
            }
            else
            {
                result = erfpuc.FiltersIsVisible = !erfpuc.FiltersIsVisible;
            }

            if(!result)
                ButtonFilters.Content = "Показати фільтри ▶";
            else
                ButtonFilters.Content = "◀ Сховати фільтри ";
        }
    }
}