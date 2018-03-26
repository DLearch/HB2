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


        List<OrdersView> filterOrderExpensRevenues;


        public HomeBugaltery()
        {
            bisnesLogic = new BisnesLogic();

            filteredListOrders = new List<OrdersView>();
            filterOrderExpensRevenues = new List<OrdersView>();

            validateLocalData();

            //validExRevOrderForType();
        }

        public List<OrdersView> ListOrders { get { if (filteredListOrders.Count == 0) return listOrders; else return filteredListOrders; } }

        // f
        public List<OrdersView> FilterOrderExpensRevenues { get { return filterOrderExpensRevenues;  } }

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
        public void addNewUser(string email, string name, string password, int famalyId)
        {
            bisnesLogic.addNewUser(email, name, password, famalyId);
            validateLocalData();
        }

        //CHANGE local user
        public void changeDataCurentUser(int id, string email, string name, string pass, int familyId)
        {
            bisnesLogic.changeCurentUser(id, email, name, pass, familyId);
            validateLocalData();
        }

        // Delete user for Id
        public void deleteUser(int id)
        {
            bisnesLogic.deleteUser(id);
            validateLocalData();
        }

        public void validateLocalData()
        {
            // Valid data with
            listOrders = bisnesLogic.getAllOrders();
            listCategories = bisnesLogic.getAllCategory();
            listUsers = bisnesLogic.getAllUsers();


        }

        // Suma for prise
        public decimal summPrice(bool type)
        {
            return bisnesLogic.getSumPriceOrdersForType(type);
        }
        

        // data Orders for expenses,  revenues
        public decimal applyFiltersForExpensRevenues(bool type, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            filterOrderExpensRevenues.Clear();
            decimal sum = 0;
            
            foreach (OrdersView order in listOrders)
            {
                bool orderCategoryType = listCategories.Where(c => c.Name == order.CategoryName).FirstOrDefault().Type;

                if ((dateFrom == null || order.DateOrder >= dateFrom) && (dateTo == null || order.DateOrder <= dateTo) &&
                    (type == orderCategoryType))
                {
                    sum += order.Price;
                    filterOrderExpensRevenues.Add(order);
                }
            }
            return sum;

        }

    

        // Filter for Orders
        public void aplyOrdersFilters(List<string> categoriesNames, List<string> usersNames = null, DateTime? dateFrom = null , DateTime? dateTo = null)
        {
            filteredListOrders.Clear();

            foreach(OrdersView order in listOrders)
            {
                if ((categoriesNames == null || categoriesNames.IndexOf(order.CategoryName) != -1) &&
                    (usersNames == null || usersNames.IndexOf(order.UserName) != -1) &&
                     (dateFrom == null || dateFrom <= order.DateOrder) && (dateTo == null || dateTo >= order.DateOrder))
                {
                    filteredListOrders.Add(order);
                }

            }
        }

        public void ClearOrdersFilters()
        {
            filteredListOrders.Clear();
        }

        public string getFamilyName(int id)
        {
           var fam = bisnesLogic.getFamilyName(id).Name;
            return fam;
        }


       
    }
}
