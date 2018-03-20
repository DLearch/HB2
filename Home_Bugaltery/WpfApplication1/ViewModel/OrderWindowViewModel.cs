using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.Infrastructure;

namespace WpfApplication1.ViewModel
{
    class OrderWindowViewModel : ViewModelBase
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

        #region ComboBoxCategoriesSelectedIndex

        private int _comboBoxCategoriesSelectedIndex;
        public int ComboBoxCategoriesSelectedIndex
        {
            get { return _comboBoxCategoriesSelectedIndex; }
            set
            {
                _comboBoxCategoriesSelectedIndex = value;
                OnPropertyChanged("ComboBoxCategoriesSelectedIndex");
            }
        }

        #endregion

        #region ComboBoxCategoriesItemsSource

        private IEnumerable<object> _comboBoxCategoriesItemsSource;
        public IEnumerable<object> ComboBoxCategoriesItemsSource
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

        #region ComboBoxUsersSelectedIndex

        private int _comboBoxUsersSelectedIndex;
        public int ComboBoxUsersSelectedIndex
        {
            get { return _comboBoxUsersSelectedIndex; }
            set
            {
                _comboBoxUsersSelectedIndex = value;
                OnPropertyChanged("ComboBoxUsersSelectedIndex");
            }
        }

        #endregion

        #region ComboBoxUsersItemsSource

        private IEnumerable<object> _comboBoxUsersItemsSource;
        public IEnumerable<object> ComboBoxUsersItemsSource
        {
            get { return _comboBoxUsersItemsSource; }
            set
            {
                _comboBoxUsersItemsSource = value;
                OnPropertyChanged("ComboBoxUsersItemsSource");
            }
        }

        #endregion

        #region DatePickerDateSelectedDate

        private DateTime _datePickerDateSelectedDate;
        public DateTime DatePickerDateSelectedDate
        {
            get { return _datePickerDateSelectedDate; }
            set
            {
                _datePickerDateSelectedDate = value;
                OnPropertyChanged("DatePickerDateSelectedDate");
            }
        }

        #endregion

        #region TextBoxPriceText

        private string _textBoxPriceText;
        public string TextBoxPriceText
        {
            get { return _textBoxPriceText; }
            set
            {
                _textBoxPriceText = value;
                OnPropertyChanged("TextBoxPriceText");
            }
        }

        #endregion

        #region TextBoxDescriptionText

        private string _textBoxDescriptionText;
        public string TextBoxDescriptionText
        {
            get { return _textBoxDescriptionText; }
            set
            {
                _textBoxDescriptionText = value;
                OnPropertyChanged("TextBoxDescriptionText");
            }
        }

        #endregion
        
        public IEnumerable<Users> Users
        {
            set
            {
                ComboBoxUsersItemsSource = value;
            }
            get
            {
                return ComboBoxUsersItemsSource as IEnumerable<Users>;
            }
        }

        public IEnumerable<Categories> Categories
        {
            set
            {
                ComboBoxCategoriesItemsSource = value;
            }
            get
            {
                return ComboBoxCategoriesItemsSource as IEnumerable<Categories>;
            }
        }

        
        public OrdersView Order
        {
            get
            {
                decimal price;
                if (decimal.TryParse(TextBoxPriceText, out price))
                    return new OrdersView()
                    {
                        CategoryName = (ComboBoxCategoriesSelectedItem as Categories).Name,
                        UserName = (ComboBoxUsersSelectedItem as Users).Name,
                        DateOrder = DatePickerDateSelectedDate,
                        Price = price,
                        Description = TextBoxDescriptionText
                    };

                throw new Exception("Ошибка парсинга TextBoxPriceText в decimal");
            }
            set
            {
                ComboBoxCategoriesSelectedIndex = -1;
                for (int i = 0; i < Categories.Count(); i++)
                {
                    if (Categories.ElementAt(i).Name == value.CategoryName)
                    {
                        ComboBoxCategoriesSelectedIndex = i;
                        break;
                    }
                }
                if (ComboBoxCategoriesSelectedIndex == -1)
                    throw new Exception(value.CategoryName + " - не найдено.");

                ComboBoxUsersSelectedIndex = -1;
                for (int i = 0; i < Users.Count(); i++)
                {
                    if (Users.ElementAt(i).Name == value.UserName)
                    {
                        ComboBoxUsersSelectedIndex = i;
                        break;
                    }
                }
                if (ComboBoxUsersSelectedIndex == -1)
                    throw new Exception(value.UserName + " - не найдено.");

                DatePickerDateSelectedDate = value.DateOrder;
                TextBoxPriceText = value.Price.ToString();
                TextBoxDescriptionText = value.Description;
            }
        }

        public OrderWindowViewModel()
        {
            DatePickerDateSelectedDate = DateTime.Now;
        }


        #region Ok Command

        RelayCommand _okCommand;
        public System.Windows.Input.ICommand OkCommand
        {
            get
            {
                if (_okCommand == null)
                    _okCommand = new RelayCommand(ExecuteOkCommand);
                return _okCommand;
            }
        }

        public void ExecuteOkCommand(object parameter)
        {
            DialogResult = true;
            Close();
        }

        #endregion
    }
}
