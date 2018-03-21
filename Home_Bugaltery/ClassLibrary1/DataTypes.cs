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
        public System.DateTime DateOrder { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }

   
}
