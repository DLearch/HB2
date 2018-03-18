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
        List<OrdersView> listOrders;
        List<Categories_HB> listCategories;
        List<Users_HB> listUsers;

        public HomeBugaltery()
        {
            bisnesLogic = new BisnesLogic();
            validateLocalData();
        }

        public List<OrdersView> ListOrders { get { return listOrders; } }

        public List<Categories_HB> ListCategories { get { return listCategories; } }
        public List<Users_HB> ListUsers { get { return listUsers; } }

        public void addOrder(string categoryName, string userName, DateTime dateOrder, decimal price, string description)
        {
            bisnesLogic.AddOrder(categoryName, userName, dateOrder, price, description);
        }

        public void addCategory(string gategoryName)
        {

        }

        public void validateLocalData()
        {
            // Valid data with
            listOrders = bisnesLogic.GetAllOrders();
            listCategories = bisnesLogic.GetAllCategory();
            listUsers = bisnesLogic.GetAllUsers();
        }
    }
}
