using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class OrdersView
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string UserName { get; set; }
        public DateTime DateOrder { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string PriceString
        {
            get
            {
                return Price.ToString("G29");
            }
        }
        public string DateOrderShortString
        {
            get
            {
                return DateOrder.ToShortDateString();
            }
        }
    }

    public class UserSaldo
    {
        public string UserName { get; set; }
        public decimal Debet { get; set; }
        public decimal Credit { get; set; }
        public decimal Saldo { get; set; }

        public string DebetString
        {
            get
            {
                return Debet.ToString("G29");
            }
        }
        public string CreditString
        {
            get
            {
                return Credit.ToString("G29");
            }
        }
        public string SaldoString
        {
            get
            {
                return Saldo.ToString("G29");
            }
        }
    }

   
}
