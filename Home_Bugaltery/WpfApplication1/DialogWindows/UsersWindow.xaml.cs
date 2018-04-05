using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        HomeBugaltery hb;
        Users user;
        ObservableCollection<Users> users;

        public UsersWindow(HomeBugaltery hb, Users user)
        {
            InitializeComponent();

            this.hb = hb;

            Title = hb.getFamilyName(user.Family_Id);

            this.user = user;
            ListBoxUsers.ItemsSource = users = new ObservableCollection<Users>();

            TextBoxEditName.Text = user.Name;
            TextBoxEditEmail.Text = user.Email;
            TextBoxEditPassword.Text = user.Password;

            UpdateListBoxUsers();
            ButtonRemoveUser.IsEnabled = false;
        }

        void UpdateListBoxUsers()
        {
            users.Clear();

            foreach (var item in hb.ListUsers)
                users.Add(item);
        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckAddFields())
                return;

            hb.addNewUser(TextBoxAddEmail.Text, TextBoxAddName.Text, TextBoxAddPassword.Text, user.Family_Id);
            UpdateListBoxUsers();
        }

        bool CheckAddFields()
        {
            bool result = true;
            
            if (users.Any(c => c.Name == TextBoxAddName.Text))
            {
                TextBlockAddNameError.Text = "Користувач з таким ім'ям вже існуе!";
                TextBoxAddName.BorderBrush = Brushes.Red;
                result = false;
            }
            if (users.Any(c => c.Email == TextBoxAddEmail.Text))
            {
                TextBlockAddEmailError.Text = "Користувач з таким Email вже існуе!";
                TextBoxAddEmail.BorderBrush = Brushes.Red;
                result = false;
            }
            if (TextBoxAddPassword.Text.Length < 4)
            {
                TextBlockAddPasswordError.Text = "Занадто короткий пароль!";
                TextBoxAddPassword.BorderBrush = Brushes.Red;
                result = false;
            }
            if (TextBoxAddPassword.Text.Length > 30)
            {
                TextBlockAddPasswordError.Text = "Занадто довгий пароль!";
                TextBoxAddPassword.BorderBrush = Brushes.Red;
                result = false;
            }

            if (CheckIsNotNullOrEmpty(TextBlockAddNameError, TextBoxAddName))
                result = false;
            if (CheckIsNotNullOrEmpty(TextBlockAddEmailError, TextBoxAddEmail))
                result = false;
            if (CheckIsNotNullOrEmpty(TextBlockAddPasswordError, TextBoxAddPassword))
                result = false;

            return result;
        }

        bool CheckIsNotNullOrEmpty(TextBlock error, TextBox textBox)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
                return true;

            error.Text = "Заповніть поле!";
            textBox.BorderBrush = Brushes.Red;

            return false;
        }

        private void ButtonEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEditFields())
                return;

            hb.changeDataCurentUser(user.Id, TextBoxEditEmail.Text, TextBoxEditName.Text, TextBoxEditPassword.Text);
            UpdateListBoxUsers();
        }

        bool CheckEditFields()
        {
            bool result = true;

            if (users.Any(c => c.Name == TextBoxEditName.Text && c.Id != user.Id))
            {
                TextBlockEditNameError.Text = "Користувач з таким ім'ям вже існуе!";
                TextBoxEditName.BorderBrush = Brushes.Red;
                result = false;
            }
            if (users.Any(c => c.Email == TextBoxEditEmail.Text && c.Id != user.Id))
            {
                TextBlockEditEmailError.Text = "Користувач з таким Email вже існуе!";
                TextBoxEditEmail.BorderBrush = Brushes.Red;
                result = false;
            }
            if (TextBoxEditPassword.Text.Length < 4)
            {
                TextBlockEditPasswordError.Text = "Занадто короткий пароль!";
                TextBoxEditPassword.BorderBrush = Brushes.Red;
                result = false;
            }
            if (TextBoxEditPassword.Text.Length > 30)
            {
                TextBlockEditPasswordError.Text = "Занадто довгий пароль!";
                TextBoxEditPassword.BorderBrush = Brushes.Red;
                result = false;
            }

            if (CheckIsNotNullOrEmpty(TextBlockEditNameError, TextBoxEditName))
                result = false;
            if (CheckIsNotNullOrEmpty(TextBlockEditEmailError, TextBoxEditEmail))
                result = false;
            if (CheckIsNotNullOrEmpty(TextBlockEditPasswordError, TextBoxEditPassword))
                result = false;

            return result;
        }

        private void ButtonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            hb.deleteUser((ListBoxUsers.SelectedItem as Users).Id);
            UpdateListBoxUsers();
        }

        private void ListBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Users selectedUser = ListBoxUsers.SelectedItem as Users;
            if (selectedUser == null || hb.ListOrders.Any(o => o.UserName == selectedUser.Name))
            {
                ButtonRemoveUser.IsEnabled = false;
                return;
            }

            ButtonRemoveUser.IsEnabled = true;
        }
        

        private void TextBoxEditName_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockEditNameError.Text = string.Empty;
            TextBoxEditName.BorderBrush = Brushes.LightGray;
        }

        private void TextBoxEditEmail_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockEditEmailError.Text = string.Empty;
            TextBoxEditEmail.BorderBrush = Brushes.LightGray;
        }

        private void TextBoxEditPassword_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockEditPasswordError.Text = string.Empty;
            TextBoxEditPassword.BorderBrush = Brushes.LightGray;
        }

        private void TextBoxAddName_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockAddNameError.Text = string.Empty;
            TextBoxAddName.BorderBrush = Brushes.LightGray;
        }

        private void TextBoxAddEmail_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockAddEmailError.Text = string.Empty;
            TextBoxAddEmail.BorderBrush = Brushes.LightGray;
        }

        private void TextBoxAddPassword_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockAddPasswordError.Text = string.Empty;
            TextBoxAddPassword.BorderBrush = Brushes.LightGray;
        }
    }
}
