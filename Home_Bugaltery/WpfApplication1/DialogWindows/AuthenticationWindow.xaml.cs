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

namespace WpfApplication1.DialogWindows
{
    /// <summary>
    /// Interaction logic for AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        public Users User { get; set; }

        HomeBugaltery hb;
        public AuthenticationWindow(HomeBugaltery hb)
        {
            InitializeComponent();

            this.hb = hb;
        }
        private void ButtonAuthentication_Click(object sender, RoutedEventArgs e)
        {
            User = hb.ListUsers.First(u => u.Name == TextBoxName.Text && u.Password == PasswordBoxPassword.Password);
            if (User != null)
            {
                DialogResult = true;
                Close();
            }
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
        }

    }
}
