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
        }

        void UpdateListBoxUsers()
        {
            users.Clear();

            foreach (var item in hb.ListUsers)
                users.Add(item);
        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            hb.addNewUser(TextBoxAddEmail.Text, TextBoxAddName.Text, TextBoxAddPassword.Text, user.Family_Id);
            UpdateListBoxUsers();
        }
        private void ButtonEditUser_Click(object sender, RoutedEventArgs e)
        {
            hb.changeDataCurentUser(user.Id, TextBoxEditEmail.Text, TextBoxEditName.Text, TextBoxEditPassword.Text);
            UpdateListBoxUsers();
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

        }

        private void TextBoxEditEmail_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBoxEditPassword_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
