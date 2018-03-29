using ClassLib;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HomeBugaltery homeBugaltery;
        OrdersUserControl ouc;

        public MainWindow()
        {
            InitializeComponent();
            
            homeBugaltery = new HomeBugaltery();

            ouc = new OrdersUserControl(homeBugaltery);
            GridMain.Children.Add(ouc);

            UpdateAll();
        }

        #region Update
        
        void UpdateAll()
        {
            ouc.UpdateAll();
        }

        #endregion

        private void MenuItemFamilyMembers_Click(object sender, RoutedEventArgs e)
        {
            FamilyMembersWindow w = new FamilyMembersWindow(homeBugaltery);

            w.ShowDialog();

            UpdateAll();
        }

        private void MenuItemCategories_Click(object sender, RoutedEventArgs e)
        {
            CategoriesWindow w = new CategoriesWindow(homeBugaltery);

            w.ShowDialog();

            UpdateAll();
        }

        private void MenuItemAddOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow w = new OrderWindow(homeBugaltery);

            if(w.ShowDialog() == true)
                UpdateAll();
        }
        
        private void Window_Closed(object sender, EventArgs e)
        {
        }
    }
}
