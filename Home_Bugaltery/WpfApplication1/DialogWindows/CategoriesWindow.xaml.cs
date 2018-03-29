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
    /// Interaction logic for CategoriesWindow.xaml
    /// </summary>
    public partial class CategoriesWindow : Window
    {
        HomeBugaltery hb;
        ObservableCollection<Categories> categories;

        public CategoriesWindow(HomeBugaltery hb)
        {
            InitializeComponent();

            this.hb = hb;

            ListBoxCategories.ItemsSource = categories = new ObservableCollection<Categories>();

            UpdateListBoxCategories();
        }

        void UpdateListBoxCategories()
        {
            categories.Clear();

            foreach (var item in hb.ListCategories)
                categories.Add(item);
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            hb.addCategory(TextBoxAddCategory.Text, RadioButtonAddCategoryIncome.IsChecked == true);

            UpdateListBoxCategories();
        }

        private void ButtonEditCategory_Click(object sender, RoutedEventArgs e)
        {
            hb.changeCategory((ListBoxCategories.SelectedItem as Categories).Id, TextBoxEditCategory.Text, RadioButtonEditCategoryIncome.IsChecked == true);

            UpdateListBoxCategories();
        }

        private void ButtonRemoveCategory_Click(object sender, RoutedEventArgs e)
        {
            hb.deleteCategory((ListBoxCategories.SelectedItem as Categories).Id);

            UpdateListBoxCategories();
        }

        private void ListBoxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categories category = ListBoxCategories.SelectedItem as Categories;

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

                if (hb.ListOrders.Any(o => o.CategoryName == category.Name))
                    ButtonRemoveCategory.IsEnabled = false;
            }
            else
                TextBoxEditCategory.Text = string.Empty;

        }
    }
}
