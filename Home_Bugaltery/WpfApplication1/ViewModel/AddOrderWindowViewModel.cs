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
        private object _comboBoxCategorySelectedItem;
        public object ComboBoxCategorySelectedItem
        {
            get { return _comboBoxCategorySelectedItem; }
            set
            {
                _comboBoxCategorySelectedItem = value;
                OnPropertyChanged("ComboBoxCategorySelectedItem");
            }
        }

        #region Add Command

        RelayCommand _addCommand;
        public ICommand Add
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(ExecuteAddCommand, CanExecuteAddCommand);
                return _addCommand;
            }
        }

        public void ExecuteAddCommand(object parameter)
        {
        }

        public bool CanExecuteAddCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region Cancel Command

        RelayCommand _cancelCommand;
        public ICommand Cancel
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
                return _cancelCommand;
            }
        }

        public void ExecuteCancelCommand(object parameter)
        {
        }

        public bool CanExecuteCancelCommand(object parameter)
        {
            return true;
        }

        #endregion
    }
}
