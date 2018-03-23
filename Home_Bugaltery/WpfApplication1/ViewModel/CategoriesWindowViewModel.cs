using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Infrastructure;

namespace WpfApplication1.ViewModel
{
    class CategoriesWindowViewModel : ViewModelBase
    {
        #region ListBoxCategoriesSelectedItem

        private object _listBoxCategoriesSelectedItem;
        public object ListBoxCategoriesSelectedItem
        {
            get { return _listBoxCategoriesSelectedItem; }
            set
            {
                _listBoxCategoriesSelectedItem = value;
                OnPropertyChanged("ListBoxCategoriesSelectedItem");
            }
        }

        #endregion

        #region TextBoxAddCategoryText

        private string _textBoxAddCategoryText;
        public string TextBoxAddCategoryText
        {
            get { return _textBoxAddCategoryText; }
            set
            {
                _textBoxAddCategoryText = value;
                OnPropertyChanged("TextBoxAddCategoryText");
            }
        }

        #endregion

        #region TextBoxEditCategoryText

        private string _textBoxEditCategoryText;
        public string TextBoxEditCategoryText
        {
            get { return _textBoxEditCategoryText; }
            set
            {
                _textBoxEditCategoryText = value;
                OnPropertyChanged("TextBoxEditCategoryText");
            }
        }

        #endregion

        #region ListBoxCategoriesItemsSource

        private IEnumerable<object> _listBoxCategoriesItemsSource;
        public IEnumerable<object> ListBoxCategoriesItemsSource
        {
            get { return _listBoxCategoriesItemsSource; }
            set
            {
                _listBoxCategoriesItemsSource = value;
                OnPropertyChanged("ListBoxCategoriesItemsSource");
            }
        }

        #endregion

        #region TextBoxEditCategoryIsEnabled

        private bool _textBoxEditCategoryIsEnabled;
        public bool TextBoxEditCategoryIsEnabled
        {
            get { return _textBoxEditCategoryIsEnabled; }
            set
            {
                _textBoxEditCategoryIsEnabled = value;
                OnPropertyChanged("TextBoxEditCategoryIsEnabled");
            }
        }

        #endregion

        #region RadioButtonEditCategoryIncomeIsChecked

        private bool _radioButtonEditCategoryIncomeIsChecked;
        public bool RadioButtonEditCategoryIncomeIsChecked
        {
            get { return _radioButtonEditCategoryIncomeIsChecked; }
            set
            {
                _radioButtonEditCategoryIncomeIsChecked = value;
                OnPropertyChanged("RadioButtonEditCategoryIncomeIsChecked");
            }
        }

        #endregion

        #region RadioButtonEditCategoryOutcomeIsChecked

        private bool _radioButtonEditCategoryOutcomeIsChecked;
        public bool RadioButtonEditCategoryOutcomeIsChecked
        {
            get { return _radioButtonEditCategoryOutcomeIsChecked; }
            set
            {
                _radioButtonEditCategoryOutcomeIsChecked = value;
                OnPropertyChanged("RadioButtonEditCategoryOutcomeIsChecked");
            }
        }

        #endregion

        #region GroupBoxEditCategoryIsEnabled

        private bool _groupBoxEditCategoryIsEnabled;
        public bool GroupBoxEditCategoryIsEnabled
        {
            get { return _groupBoxEditCategoryIsEnabled; }
            set
            {
                _groupBoxEditCategoryIsEnabled = value;
                OnPropertyChanged("GroupBoxEditCategoryIsEnabled");
            }
        }

        #endregion

        ObservableCollection<Categories> categories;
        HomeBugaltery _homeBugaltery;

        public HomeBugaltery HomeBugaltery
        {
            set
            {
                _homeBugaltery = value;
                ListBoxCategoriesItemsSource = categories = new ObservableCollection<Categories>();
                UpdateListBoxCategories();
            }
            private get
            {
                return _homeBugaltery;
            }
        }

        private void UpdateListBoxCategories()
        {
            categories.Clear();
            foreach (Categories category in HomeBugaltery.ListCategories)
                categories.Add(category);
        }

        #region Add Category Command

        RelayCommand _addCategoryCommand;
        public System.Windows.Input.ICommand AddCategoryCommand
        {
            get
            {
                if (_addCategoryCommand == null)
                    _addCategoryCommand = new RelayCommand(ExecuteAddCategoryCommand);
                return _addCategoryCommand;
            }
        }

        public void ExecuteAddCategoryCommand(object parameter)
        {
            bool isIncome = (bool)parameter;

            HomeBugaltery.addCategory( TextBoxAddCategoryText, isIncome);

            UpdateListBoxCategories();
        }

        #endregion

        # region Edit Category Command

        RelayCommand _editCategoryCommand;
        public System.Windows.Input.ICommand EditCategoryCommand
        {
            get
            {
                if (_editCategoryCommand == null)
                    _editCategoryCommand = new RelayCommand(ExecuteEditCategoryCommand, CanExecuteEditCategoryCommand);
                return _editCategoryCommand;
            }
        }

        public void ExecuteEditCategoryCommand(object parameter)
        {
            
            UpdateListBoxCategories();
        }

        public bool CanExecuteEditCategoryCommand(object parameter)
        {
            if (ListBoxCategoriesSelectedItem == null)
            {
                TextBoxEditCategoryText = string.Empty;
                GroupBoxEditCategoryIsEnabled = TextBoxEditCategoryIsEnabled = false;
                return false;
            }

            Categories curCategory = ListBoxCategoriesSelectedItem as Categories;

            if (curCategory.Type)
                RadioButtonEditCategoryIncomeIsChecked = true;
            else
                RadioButtonEditCategoryOutcomeIsChecked = true;
            TextBoxEditCategoryText = curCategory.Name;
            GroupBoxEditCategoryIsEnabled = TextBoxEditCategoryIsEnabled = true;

            return true;
        }

        #endregion

        #region Remove Category Command

        RelayCommand _removeCategoryCommand;
        public System.Windows.Input.ICommand RemoveCategoryCommand
        {
            get
            {
                if (_removeCategoryCommand == null)
                    _removeCategoryCommand = new RelayCommand(ExecuteRemoveCategoryCommand, CanExecuteRemoveCategoryCommand);
                return _removeCategoryCommand;
            }
        }

        public void ExecuteRemoveCategoryCommand(object parameter)
        {

            UpdateListBoxCategories();
        }

        public bool CanExecuteRemoveCategoryCommand(object parameter)
        {
            return ListBoxCategoriesSelectedItem != null;
        }

        #endregion
    }
}
