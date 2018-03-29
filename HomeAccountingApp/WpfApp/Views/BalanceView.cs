using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Views
{
    public class BalanceView
    {
        public int FamilyMemberId { get; set; }

        public decimal Income { get; set; }

        public decimal Outcome { get; set; }

        public decimal Balance
        {
            get
            {
                return Income + (Outcome * -1);
            }
        }
    }
}
