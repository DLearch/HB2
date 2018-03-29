using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.FilterItems
{
    class FilterCategoriesItem
    {
        public bool IsSelected { get; set; }

        public Categories Category { get; set; }

        public FilterCategoriesItem(bool isSelected, Categories category)
        {
            IsSelected = isSelected;
            Category = category;
        }
    }
}
