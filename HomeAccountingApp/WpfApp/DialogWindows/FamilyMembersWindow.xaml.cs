using ClassLib;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for FamilyMembersWindow.xaml
    /// </summary>
    public partial class FamilyMembersWindow : Window
    {
        HomeAccounting ha;

        ObservableCollection<FamilyMember> familyMembers;
        public FamilyMembersWindow(HomeAccounting ha)
        {
            InitializeComponent();

            this.ha = ha;

            ListBoxFamilyMembers.ItemsSource = familyMembers = new ObservableCollection<FamilyMember>();

            UpdateListBoxFamilyMembers();
        }

        void UpdateListBoxFamilyMembers()
        {
            familyMembers.Clear();

            foreach (var item in ha.FamilyMembers)
                familyMembers.Add(item);
        }

        private void ButtonAddFamilyMember_Click(object sender, RoutedEventArgs e)
        {
            ha.AddFamilyMember(TextBoxAddFamilyMember.Text);

            UpdateListBoxFamilyMembers();
        }

        private void ButtonEditFamilyMember_Click(object sender, RoutedEventArgs e)
        {
            ha.EditFamilyMember(new FamilyMember() {
                Id = (ListBoxFamilyMembers.SelectedItem as FamilyMember).Id,
                Name = TextBoxEditFamilyMember.Text
            });

            UpdateListBoxFamilyMembers();
        }

        private void ButtonRemoveFamilyMember_Click(object sender, RoutedEventArgs e)
        {
            ha.RemoveFamilyMember((ListBoxFamilyMembers.SelectedItem as FamilyMember).Id);

            UpdateListBoxFamilyMembers();
        }

        private void ListBoxFamilyMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FamilyMember familyMember = ListBoxFamilyMembers.SelectedItem as FamilyMember;

            bool val = familyMember != null;

            TextBoxEditFamilyMember.IsEnabled = val;
            ButtonEditFamilyMember.IsEnabled = val;
            ButtonRemoveFamilyMember.IsEnabled = val;

            if (val)
            {
                TextBoxEditFamilyMember.Text = familyMember.Name;

                if (ha.Orders.Any(o => o.FamilyMemberId == familyMember.Id))
                    ButtonRemoveFamilyMember.IsEnabled = false;
            }
            else
                TextBoxEditFamilyMember.Text = string.Empty;
        }
    }
}
