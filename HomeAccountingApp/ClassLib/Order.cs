using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Order
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int FamilyMemberId { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
        
        public string Description { get; set; }
    }
}
