using ClassLib;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        HomeAccounting ha;
        public AuthenticationWindow()
        {
            InitializeComponent();

            ha = new HomeAccounting();
        }

        private void ButtonAuthentication_Click(object sender, RoutedEventArgs e)
        {
            if (ha.Authentication(TextBoxEmail.Text, PasswordBoxPassword.Password))
            {
                OpenMainWindow();
                Close();
            }
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow(ha);

            Hide();
            if(rw.ShowDialog() == true)
            {
                OpenMainWindow();
                Close();
            }
            Show();
        }

        void OpenMainWindow()
        {
            //MainWindow mw = new MainWindow(ha);
            //mw.Show();
        }
    }
}
