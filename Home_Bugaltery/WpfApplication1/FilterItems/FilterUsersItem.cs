using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.FilterItems
{
    class FilterUsersItem
    {
        public bool IsSelected { get; set; }

        public Users User { get; set; }

        public FilterUsersItem(bool isSelected, Users user)
        {
            IsSelected = isSelected;
            User = user;
        }
    }
}
