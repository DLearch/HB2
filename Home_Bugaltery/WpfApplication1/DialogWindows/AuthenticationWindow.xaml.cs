using ClassLibrary1;
using System;
using System.Collections.Generic;
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

            DataContext = this;

            this.hb = hb;
        }
        private void ButtonAuthentication_Click(object sender, RoutedEventArgs e)
        {
            TextBlockError.Text = string.Empty;
            if (!CheckFields())
                return;

            User = hb.ListUsers.FirstOrDefault(u => u.Name == TextBoxName.Text && u.Password == PasswordBoxPassword.Password);

            if (User != null)
            {
                DialogResult = true;
                Close();
            }
            else
                TextBlockError.Text = "Неправильний пароль або ім'я";
        }

        bool CheckFields()
        {
            bool result = true;

            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                TextBlockNameError.Text = "Заповніть поле!";
                result = false;
            }

            if (string.IsNullOrEmpty(PasswordBoxPassword.Password))
            {
                TextBlockPasswordError.Text = "Заповніть поле!";
                result = false;
            }

            return result;
        }


        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
        }

        private void PasswordBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockPasswordError.Text = string.Empty;
        }

        private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockNameError.Text = string.Empty;
        }
    }
}
