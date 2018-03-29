using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class FilterCategoriesItem
    {
        public bool IsSelected { get; set; }

        public Category Category { get; set; }

        public FilterCategoriesItem(bool isSelected, Category category)
        {
            IsSelected = isSelected;
            Category = category;
        }
    }
}
