using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Infrastructure;

namespace WpfApplication1.ViewModel
{
    class LoginWindowViewModel : ViewModelBase
    {
        #region TextBoxLoginText

        private object _textBoxLoginText;
        public object TextBoxLoginText
        {
            get { return _textBoxLoginText; }
            set
            {
                _textBoxLoginText = value;
                OnPropertyChanged("TextBoxLoginText");
            }
        }

        #endregion

        #region TextBoxPasswordText

        private object _textBoxPasswordText;
        public object TextBoxPasswordText
        {
            get { return _textBoxPasswordText; }
            set
            {
                _textBoxPasswordText = value;
                OnPropertyChanged("TextBoxPasswordText");
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
            }
            private get
            {
                return _homeBugaltery;
            }
        }

        #endregion 

        #region Authentication Command

        RelayCommand _authenticationCommand;
        public System.Windows.Input.ICommand AuthenticationCommand
        {
            get
            {
                if (_authenticationCommand == null)
                    _authenticationCommand = new RelayCommand(ExecuteAuthenticationCommand);
                return _authenticationCommand;
            }
        }

        public void ExecuteAuthenticationCommand(object parameter)
        {
        }

        #endregion

        #region Authentication Command

        RelayCommand _registrationCommand;
        public System.Windows.Input.ICommand RegistrationCommand
        {
            get
            {
                if (_registrationCommand == null)
                    _registrationCommand = new RelayCommand(ExecuteRegistrationCommand);
                return _registrationCommand;
            }
        }

        public void ExecuteRegistrationCommand(object parameter)
        {
        }

        #endregion
    }
}
