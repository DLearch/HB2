using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.Infrastructure;

namespace WpfApplication1.ViewModel
{
    class AddOrderWindowViewModel : ViewModelBase
    {
        #region ComboBoxCategoriesSelectedItem

        private object _comboBoxCategoriesSelectedItem;
        public object ComboBoxCategoriesSelectedItem
        {
            get { return _comboBoxCategoriesSelectedItem; }
            set
            {
                _comboBoxCategoriesSelectedItem = value;
                OnPropertyChanged("ComboBoxCategoriesSelectedItem");
            }
        }

        #endregion

        #region ComboBoxCategoriesItemsSource

        private object _comboBoxCategoriesItemsSource;
        public object ComboBoxCategoriesItemsSource
        {
            get { return _comboBoxCategoriesItemsSource; }
            set
            {
                _comboBoxCategoriesItemsSource = value;
                OnPropertyChanged("ComboBoxCategoriesItemsSource");
            }
        }

        #endregion

        #region ComboBoxUsersSelectedItem

        private object _comboBoxUsersSelectedItem;
        public object ComboBoxUsersSelectedItem
        {
            get { return _comboBoxUsersSelectedItem; }
            set
            {
                _comboBoxUsersSelectedItem = value;
                OnPropertyChanged("ComboBoxUsersSelectedItem");
            }
        }

        #endregion

        #region ComboBoxUsersItemsSource

        private object _comboBoxUsersItemsSource;
        public object ComboBoxUsersItemsSource
        {
            get { return _comboBoxUsersItemsSource; }
            set
            {
                _comboBoxUsersItemsSource = value;
                OnPropertyChanged("ComboBoxUsersItemsSource");
            }
        }

        #endregion
        


        #region Add Command

        RelayCommand _addCommand;
        public ICommand Add
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(ExecuteAddCommand);
                return _addCommand;
            }
        }

        public void ExecuteAddCommand(object parameter)
        {
        }

        #endregion
    }
}
