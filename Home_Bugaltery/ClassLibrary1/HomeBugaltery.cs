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
        List<OrdersView> filteredListOrders;
        List<Categories> listCategories;
        List<Users> listUsers;

        public HomeBugaltery()
        {
            bisnesLogic = new BisnesLogic();

            filteredListOrders = new List<OrdersView>();

            validateLocalData();
        }

        public List<OrdersView> ListOrders { get { if (filteredListOrders.Count == 0) return listOrders; else return filteredListOrders; } }

        public List<Categories> ListCategories { get { return listCategories; } }
        public List<Users> ListUsers { get { return listUsers; } }

        public void addOrder(string categoryName, string userName, DateTime dateOrder, decimal price, string description)
        {
            bisnesLogic.addOrder(categoryName, userName, dateOrder, price, description);
            validateLocalData();
        }

        public void changeOrder(int id, string categoryName, string userName, DateTime dateOrder, decimal price, string description)
        {
            bisnesLogic.changeOrder(id, categoryName, userName, dateOrder, price, description);
            validateLocalData();
        }

        public void addCategory(string categoryName, bool type)
        {
            bisnesLogic.addCategory(categoryName, type);
            validateLocalData();
        }

        // deleteOrder
        public void deleteOrder(int id)
        {
            bisnesLogic.deleteOrder(id);
            validateLocalData();
        }

        // deleteCategory
        public void deleteCategory(int id)
        {
            bisnesLogic.delateCategory(id);
            validateLocalData();
        }

        // change category
        public void changeCategory(int id, string newName, bool newType)
        {
            bisnesLogic.changeCategory(id, newName, newType);
            validateLocalData();
        }

        // add user
        public void addNewUser(string email, string name, string password)
        {
            bisnesLogic.addNewUser(email, name, password);
            validateLocalData();
        }

        //CHANGE local user
        public void changeDataCurentUser(int id, string email, string name, string pass)
        {
            bisnesLogic.changeCurentUser(id, email, name, pass);
            validateLocalData();
        }

        // Delete user for Id
        public void deleteUser(int id)
        {
            bisnesLogic.delateUser(id);
            validateLocalData();
        }

        public void validateLocalData()
        {
            // Valid data with
            listOrders = bisnesLogic.getAllOrders();
            listCategories = bisnesLogic.getAllCategory();
            listUsers = bisnesLogic.getAllUsers();
        }

        // Filter for Orders
        public void aplyOrdersFilters(List<string> categoriesNames, List<string> usersNames = null, string dateFrom = null /*default(DateTime)*/, string dateTo = null)
        {
            filteredListOrders.Clear();

            foreach(OrdersView order in listOrders)
            {
                if ((categoriesNames == null || categoriesNames.IndexOf(order.CategoryName) != -1) &&
                    (usersNames == null || usersNames.IndexOf(order.UserName) != -1)) /*&&
                     (dateFrom >= order.DateOrder && dateTo <= order.DateOrder))*/
                {
                    filteredListOrders.Add(order);
                }

                //if (categoriesNames != null)
                //{
                //    foreach (string categoryName in categoriesNames)
                //    {
                //        if (order.CategoryName == categoryName)
                //        {
                //            filteredListOrders.Add(order);
                //        }
                //    }
                //}

                //if (usersNames != null)
                //{
                //    foreach (string userName in usersNames)
                //    {
                //        if (order.UserName == userName)
                //        {
                //            filteredListOrders.Add(order);
                //        }
                //    }
                //}

            }
        }

        public void ClearOrdersFilters()
        {
            filteredListOrders.Clear();
        }
       
    }
}
