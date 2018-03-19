using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        protected ViewModelBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }


        #region Обязательно избавиться

        private Window _wnd = null;

        protected bool? ShowDialog(Window window)
        {
            ViewModelBase vmb = (window.DataContext as ViewModelBase);
            vmb._wnd = window;
            return window.ShowDialog();
        }

        public bool? DialogResult
        {
            get
            {
                return _wnd.DialogResult;
            }
            set
            {
                _wnd.DialogResult = value;
            }
        }
        public bool Close()
        {
            var result = false;
            if (_wnd != null)
            {
                _wnd.Close();
                _wnd = null;
                result = true;                
            }
            return result;
        }

        #endregion
    }
}
