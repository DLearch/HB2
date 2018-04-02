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
    public partial class AuthenticationWindow : Window, IDataErrorInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "UserName":
                        if (string.IsNullOrEmpty(UserName))
                            error = "Поле пусте. ";
                        if (UserName.Length < 4)
                            error += "Занадто коротке ім'я. ";
                        if (UserName.Length > 40)
                            error += "Занадто довге ім'я. ";
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

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
            User = hb.ListUsers.FirstOrDefault(u => u.Name == TextBoxName.Text && u.Password == PasswordBoxPassword.Password);
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
