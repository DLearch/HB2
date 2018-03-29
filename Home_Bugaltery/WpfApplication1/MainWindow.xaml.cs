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

        public MainWindow()
        {
            InitializeComponent();

            hb = new HomeBugaltery();

            ouc = new OrdersUserControl(hb);
            GridMain.Children.Add(ouc);

            UpdateAll();
        }

        void UpdateAll()
        {
            ouc.UpdateAll();
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
    }
}