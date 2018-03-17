using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // 2. Иерархия исполнителей (получателей)
    // ======================================
    // 2.1. Базовый класс ...

    // 2.2. Конкретный исполнитель (получатель) :
    public class HomeBugaltery
    {

        BisnesLogic bisnesLogic;

        public HomeBugaltery()
        {
            bisnesLogic = new BisnesLogic();
        }

        public List<OrdersView> ListOrders { get { return bisnesLogic.ViewAllOrders(); } }
        public List<Categories> ListCategories { get { return bisnesLogic.ViewAllCategory(); } }
        public List<Users> ListUsers { get { return bisnesLogic.ViewAllUsers(); } }

        public void addOrder(string categoryName, string userName, DateTime dateOrder, decimal price, string description)
        {
            bisnesLogic.AddOrder(categoryName, userName, dateOrder, price, description);
        }

        public void addCategory(string gategoryName)
        {

        }
    }
}
