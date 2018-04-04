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
        #region Конструктор и поля
        
        HomeBugaltery hb = HomeBugaltery.getInstance();
        OrdersUserControl ouc;
        BalanceUserControl buc;
        ExpensesRevenuesForPeriodUserControl erfpuc;
        Users user;
        UserControl curUserControl;
        Button curButton;

        public MainWindow()
        {
            AuthenticationWindow aw = new AuthenticationWindow(hb);

            if (aw.ShowDialog() != true)
            {
                Close();
                return;
            }

            user = aw.User;

            InitializeComponent();
            
            Title = "Домашня бугалтерія - " + user.Name;

            curUserControl = ouc = new OrdersUserControl(hb);
            GridMain.Children.Add(ouc);
            GridFilters.Children.Add(ouc.FilterUserControl);

            buc = new BalanceUserControl(hb);
            GridMain.Children.Add(buc);

            erfpuc = new ExpensesRevenuesForPeriodUserControl(hb);
            GridMain.Children.Add(erfpuc);

            buc.Visibility = erfpuc.Visibility = Visibility.Collapsed;

            curButton = ButtonOrders;

            FieldChange("ButtonOrders");

            UpdateAll();
        }

        #endregion

        void UpdateAll()
        {
            ouc.UpdateAll();
            buc.UpdateAll();
            erfpuc.UpdateAll();
        }

        #region Смена полей

        void MoveTo(object sender, EventArgs e)
        {
            FieldChange((sender as Control).Name.ToString());
        }

        void FieldChange(string fieldName)
        {
            curUserControl.Visibility = Visibility.Collapsed;
            curButton.IsEnabled = true;
            GridFilters.Children.Clear();

            switch (fieldName)
            {
                case "ButtonOrders":
                    curUserControl = ouc;
                    curButton = ButtonOrders;
                    GridFilters.Children.Add(ouc.FilterUserControl);
                    break;

                case "ButtonBalance":
                    curUserControl = buc;
                    curButton = ButtonBalance;
                    GridFilters.Children.Add(buc.FilterUserControl);
                    break;

                case "ButtonIncomes":
                    curUserControl = erfpuc;
                    curButton = ButtonIncomes;
                    erfpuc.IsIncome = true;
                    erfpuc.UpdateAll();
                    GridFilters.Children.Add(erfpuc.FilterUserControlIncomes);
                    break;

                case "ButtonOutcomes":
                    curUserControl = erfpuc;
                    curButton = ButtonOutcomes;
                    erfpuc.IsIncome = false;
                    erfpuc.UpdateAll();
                    GridFilters.Children.Add(erfpuc.FilterUserControlOutcomes);
                    break;
            }

            curUserControl.Visibility = Visibility.Visible;
            curButton.IsEnabled = false;
        }

        #endregion

        #region Показ фильтров

        GridLength lastLenght;

        private void ButtonFilters_Click(object sender, RoutedEventArgs e)
        {
            if (ColumnFilters.Width.Value == 0)
            {
                if (lastLenght.Value > 150)
                    ColumnFilters.Width = lastLenght;
                else
                    ColumnFilters.Width = new GridLength(250);

                ColumnGridSplitterFilters.Width = new GridLength(4);

                ButtonFilters.Content = "◀ Сховати фільтри ";

                return;
            }

            lastLenght = ColumnFilters.Width;
            ColumnGridSplitterFilters.Width = ColumnFilters.Width = new GridLength(0);

            ButtonFilters.Content = "Показати фільтри ▶";
        }

        #endregion

        #region Показ окон категорий и пользователей

        private void ButtonCategories_Click(object sender, RoutedEventArgs e)
        {
            ShowDialogWindow(new CategoriesWindow(hb), sender as Control);
        }

        private void ButtonUsers_Click(object sender, RoutedEventArgs e)
        {
            ShowDialogWindow(new UsersWindow(hb, user), sender as Control);
        }

        void ShowDialogWindow(Window w, Control c)
        {
            c.IsEnabled = false;
            w.ShowDialog();
            c.IsEnabled = true;

            UpdateAll();
        }

        #endregion
    }
}