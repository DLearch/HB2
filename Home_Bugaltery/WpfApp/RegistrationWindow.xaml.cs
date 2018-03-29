using ClassLib;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        HomeAccounting ha;
        public RegistrationWindow(HomeAccounting ha)
        {
            InitializeComponent();

            this.ha = ha;
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxPassword.Password == PasswordBoxRePassword.Password 
                && ha.Registration(TextBoxName.Text, TextBoxEmail.Text, PasswordBoxPassword.Password))
            {
                DialogResult = true;
                Close();
            }
        }
    }
}
