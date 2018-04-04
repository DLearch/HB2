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
            ListBoxCategories_SelectionChanged(null, null);
        }

        void UpdateListBoxCategories()
        {
            categories.Clear();

            foreach (var item in hb.ListCategories)
                categories.Add(item);
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxAddCategory.Text))
            {
                TextBlockAddCategoryError.Text = "Заповніть поле!";
                TextBoxAddCategory.BorderBrush = Brushes.Red;
                return;
            }
            if (categories.Any(c => c.Name == TextBoxAddCategory.Text))
            {
                TextBlockAddCategoryError.Text = "Категорія з таким ім'ям вже існуе!";
                TextBoxAddCategory.BorderBrush = Brushes.Red;
                return;
            }

            hb.addCategory(TextBoxAddCategory.Text, RadioButtonAddCategoryIncome.IsChecked == true);

            UpdateListBoxCategories();
        }

        private void ButtonEditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxEditCategory.Text))
            {
                TextBlockEditCategoryError.Text = "Заповніть поле!";
                TextBoxEditCategory.BorderBrush = Brushes.Red;
                return;
            }
            if (categories.Any(c => c.Name == TextBoxEditCategory.Text && c.Id != (ListBoxCategories.SelectedItem as Categories).Id))
            {
                TextBlockEditCategoryError.Text = "Категорія з таким ім'ям вже існуе!";
                TextBoxEditCategory.BorderBrush = Brushes.Red;
                return;
            }

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

            GroupBoxEditCategory.IsEnabled = val;
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

        private void TextBoxAddCategory_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockAddCategoryError.Text = string.Empty;
            TextBoxAddCategory.BorderBrush = Brushes.LightGray;
        }

        private void TextBoxEditCategory_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlockEditCategoryError.Text = string.Empty;
            TextBoxEditCategory.BorderBrush = Brushes.LightGray;
        }
    }
}
