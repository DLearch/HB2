using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
