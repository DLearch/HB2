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

        #region ButtonOkContent

        private string _buttonOkContent;
        public string ButtonOkContent
        {
            get { return _buttonOkContent; }
            set
            {
                _buttonOkContent = value;
                OnPropertyChanged("ButtonOkContent");
            }
        }

        #endregion

        #region WindowTitle

        private string _windowTitle;
        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                OnPropertyChanged("WindowTitle");
            }
        }

        #endregion
        
        #region HomeBugaltery

        HomeBugaltery _homeBugaltery;
        public HomeBugaltery HomeBugaltery
        {
            set
            {
                _homeBugaltery = value;
                Update();
            }
            private get
            {
                return _homeBugaltery;
            }
        }

        #endregion

        #region Mode

        private OrderWindowMode mode;
        public OrderWindowMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
                switch (mode)
                {
                    case OrderWindowMode.Add:
                        WindowTitle = "Додати операцію";
                        ButtonOkContent = "Додати";
                        break;
                    case OrderWindowMode.Edit:
                        WindowTitle = "Змінити операцію";
                        ButtonOkContent = "Зберегти";
                        break;
                }
            }
        }
        #endregion

        #region Order

        int orderId;

        public OrdersView Order
        {
            get
            {
                decimal price;
                if (decimal.TryParse(TextBoxPriceText, out price))
                    return new OrdersView()
                    {
                        Id = orderId,
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
                orderId = value.Id;

                ComboBoxCategoriesSelectedIndex = -1;
                for (int i = 0; i<categories.Count(); i++)
                {
                    if (categories.ElementAt(i).Name == value.CategoryName)
                    {
                        ComboBoxCategoriesSelectedIndex = i;
                        break;
                    }
                }

                ComboBoxUsersSelectedIndex = -1;
                for (int i = 0; i<users.Count(); i++)
                {
                    if (users.ElementAt(i).Name == value.UserName)
                    {
                        ComboBoxUsersSelectedIndex = i;
                        break;
                    }
                }

                DatePickerDateSelectedDate = value.DateOrder;
                TextBoxPriceText = value.Price.ToString();
                TextBoxDescriptionText = value.Description;
            }
        }

        #endregion

        ObservableCollection<Categories> categories;
        ObservableCollection<Users> users;

        public OrderWindowViewModel()
        {
            ComboBoxCategoriesItemsSource = categories = new ObservableCollection<Categories>();
            ComboBoxUsersItemsSource = users = new ObservableCollection<Users>();

            DatePickerDateSelectedDate = DateTime.Now;

            Mode = OrderWindowMode.Add;
        }

        void Update()
        {
            users.Clear();
            foreach (Users user in HomeBugaltery.ListUsers)
                users.Add(user);

            categories.Clear();
            foreach (Categories categorty in HomeBugaltery.ListCategories)
                categories.Add(categorty);
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
            OrdersView order;

            switch (mode)
            {
                case OrderWindowMode.Add:

                    order = Order;

                    HomeBugaltery.addOrder(order.CategoryName,
                                        order.UserName,
                                        order.DateOrder,
                                        order.Price,
                                        order.Description);
                    Update();

                    break;
                case OrderWindowMode.Edit:

                    order = Order;

                    HomeBugaltery.changeOrder(order.Id,
                                            order.CategoryName,
                                            order.UserName,
                                            order.DateOrder,
                                            order.Price,
                                            order.Description);

                    Update();

                    break;
            }

            DialogResult = true;
            Close();
        }

        #endregion
        
    }

    enum OrderWindowMode
    {
        Add,
        Edit
    }
}
