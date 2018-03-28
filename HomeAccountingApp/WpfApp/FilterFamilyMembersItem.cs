using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class FilterFamilyMembersItem
    {
        public bool IsSelected { get; set; }

        public FamilyMember FamilyMember { get; set; }

        public FilterFamilyMembersItem(bool isSelected, FamilyMember familyMember)
        {
            IsSelected = isSelected;
            FamilyMember = familyMember;
        }
    }
}
