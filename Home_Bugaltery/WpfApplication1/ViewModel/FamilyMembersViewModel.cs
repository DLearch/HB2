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
    class FamilyMembersViewModel : ViewModelBase
    {
        #region ListBoxFamilyMembersSelectedItem

        private object _listBoxFamilyMembersSelectedItem;
        public object ListBoxFamilyMembersSelectedItem
        {
            get { return _listBoxFamilyMembersSelectedItem; }
            set
            {
                _listBoxFamilyMembersSelectedItem = value;
                OnPropertyChanged("ListBoxFamilyMembersSelectedItem");
            }
        }

        #endregion
        
        #region TextBoxEditFamilyMembersText

        private string _textBoxEditFamilyMembersText;
        public string TextBoxEditFamilyMembersText
        {
            get { return _textBoxEditFamilyMembersText; }
            set
            {
                _textBoxEditFamilyMembersText = value;
                OnPropertyChanged("TextBoxEditFamilyMembersText");
            }
        }

        #endregion

        #region ListBoxFamilyMembersItemsSource

        private IEnumerable<object> _listBoxFamilyMembersItemsSource;
        public IEnumerable<object> ListBoxFamilyMembersItemsSource
        {
            get { return _listBoxFamilyMembersItemsSource; }
            set
            {
                _listBoxFamilyMembersItemsSource = value;
                OnPropertyChanged("ListBoxFamilyMembersItemsSource");
            }
        }

        #endregion

        #region TextBoxEditFamilyMembersIsEnabled

        private bool _textBoxEditFamilyMembersIsEnabled;
        public bool TextBoxEditFamilyMembersIsEnabled
        {
            get { return _textBoxEditFamilyMembersIsEnabled; }
            set
            {
                _textBoxEditFamilyMembersIsEnabled = value;
                OnPropertyChanged("TextBoxEditFamilyMembersIsEnabled");
            }
        }

        #endregion

        ObservableCollection<Users> users;
        HomeBugaltery _homeBugaltery;

        public HomeBugaltery HomeBugaltery
        {
            set
            {
                _homeBugaltery = value;
                ListBoxFamilyMembersItemsSource = users = new ObservableCollection<Users>();
                UpdateListBoxFamilyMembers();
            }
            private get
            {
                return _homeBugaltery;
            }
        }
        
        private void UpdateListBoxFamilyMembers()
        {
            users.Clear();
            foreach (Users user in HomeBugaltery.ListUsers)
                users.Add(user);
        }

        #region Add Family Member Command

        RelayCommand _addFamilyMemberCommand;
        public System.Windows.Input.ICommand AddFamilyMemberCommand
        {
            get
            {
                if (_addFamilyMemberCommand == null)
                    _addFamilyMemberCommand = new RelayCommand(ExecuteAddFamilyMemberCommand);
                return _addFamilyMemberCommand;
            }
        }

        public void ExecuteAddFamilyMemberCommand(object parameter)
        {
            string name = parameter as string;
            

            UpdateListBoxFamilyMembers();
        }

        #endregion

        # region Edit Family Member Command

        RelayCommand _editFamilyMemberCommand;
        public System.Windows.Input.ICommand EditFamilyMemberCommand
        {
            get
            {
                if (_editFamilyMemberCommand == null)
                    _editFamilyMemberCommand = new RelayCommand(ExecuteEditFamilyMemberCommand, CanExecuteEditFamilyMemberCommand);
                return _editFamilyMemberCommand;
            }
        }

        public void ExecuteEditFamilyMemberCommand(object parameter)
        {

            UpdateListBoxFamilyMembers();
        }

        public bool CanExecuteEditFamilyMemberCommand(object parameter)
        {
            if (ListBoxFamilyMembersSelectedItem == null)
            {
                TextBoxEditFamilyMembersText = string.Empty;
                TextBoxEditFamilyMembersIsEnabled = false;
                return false;
            }

            TextBoxEditFamilyMembersText = (ListBoxFamilyMembersSelectedItem as Users).Name;
            TextBoxEditFamilyMembersIsEnabled = true;

            return true;
        }

        #endregion

        #region Remove Family Member Command

        RelayCommand _removeFamilyMemberCommand;
        public System.Windows.Input.ICommand RemoveFamilyMemberCommand
        {
            get
            {
                if (_removeFamilyMemberCommand == null)
                    _removeFamilyMemberCommand = new RelayCommand(ExecuteRemoveFamilyMemberCommand, CanExecuteRemoveFamilyMemberCommand);
                return _removeFamilyMemberCommand;
            }
        }

        public void ExecuteRemoveFamilyMemberCommand(object parameter)
        {

            UpdateListBoxFamilyMembers();
        }

        public bool CanExecuteRemoveFamilyMemberCommand(object parameter)
        {
            return ListBoxFamilyMembersSelectedItem != null;
        }

        #endregion

    }
}
