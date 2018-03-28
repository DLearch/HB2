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
    /// Interaction logic for CategoriesWindow.xaml
    /// </summary>
    public partial class CategoriesWindow : Window
    {
        HomeAccounting ha;
        ObservableCollection<Category> categories;

        public CategoriesWindow(HomeAccounting ha)
        {
            InitializeComponent();

            this.ha = ha;

            ListBoxCategories.ItemsSource = categories = new ObservableCollection<Category>();

            UpdateListBoxCategories();

            ListBoxCategories_SelectionChanged(null, null);
        }

        void UpdateListBoxCategories()
        {
            categories.Clear();

            foreach (var item in ha.Categories)
                categories.Add(item);
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            ha.AddCategory(new Category() {
                Name = TextBoxAddCategory.Text,
                Type = RadioButtonAddCategoryIncome.IsChecked == true
            });
            UpdateListBoxCategories();
        }

        private void ButtonEditCategory_Click(object sender, RoutedEventArgs e)
        {
            ha.EditCategory(new Category() {
                Id = (ListBoxCategories.SelectedItem as Category).Id,
                Name = TextBoxEditCategory.Text,
                Type = RadioButtonEditCategoryIncome.IsChecked == true
            });
            System.Windows.MessageBox.Show(ha.LastError);

            UpdateListBoxCategories();
        }

        private void ButtonRemoveCategory_Click(object sender, RoutedEventArgs e)
        {
            ha.RemoveCategory((ListBoxCategories.SelectedItem as Category).Id);

            UpdateListBoxCategories();
        }

        private void ListBoxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = ListBoxCategories.SelectedItem as Category;

            bool val = category != null;

            GroupBoxEditCategoryRB.IsEnabled = val;
            TextBoxEditCategory.IsEnabled = val;
            ButtonEditCategory.IsEnabled = val;
            ButtonRemoveCategory.IsEnabled = val;
            if (val)
            {
                if (category.Type)
                    RadioButtonEditCategoryIncome.IsChecked = true;
                else
                    RadioButtonEditCategoryOutcome.IsChecked = true;

                TextBoxEditCategory.Text = category.Name;

                if (ha.Orders.Any(o => o.CategoryId == category.Id))
                    ButtonRemoveCategory.IsEnabled = false;
            }
            else
                TextBoxEditCategory.Text = string.Empty;
            
        }
    }
}
