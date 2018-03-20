using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BisnesLogic
    {
        MarketEntities1 db;

        public BisnesLogic()
        {
            db = new MarketEntities1();

        }

        public List<Users> GetAllUsers()
        {
            var users = db.Users.Select(user => user);

            return users.ToList();
        }

        public List<Categories> GetAllCategory()
        {
            //var result = from i in db.Categories
            //           select i;


            var result = db.Categories.Select(c => c);

            return result.ToList();
        }

        public List<OrdersView> GetAllOrders()
        {

            var result = (from order in db.Orders
                          join category in db.Categories on order.Category_Id equals category.Id
                          join user in db.Users on order.User_Id equals user.Id
                          select new OrdersView
                          {
                              CategoryName = category.Name,
                              UserName = user.Name,
                              DateOrder = order.Date,
                              Price = order.Price,
                              Description = order.Description
                          }).ToList();


            return result;
        }

        public string GetCategoryName(int index)
        {
            var categoryName = db.Categories.FirstOrDefault(categ => categ.Id == index).Name;

            return categoryName;
        }

        public void AddOrder(string categoryName, string userName, DateTime dateOrder, decimal price, string description)
        {
            var categoryId = db.Categories.Where(cat => cat.Name == categoryName)
                                          .Select(x => x.Id).FirstOrDefault();

            var userId = db.Users.Where(user => user.Name == userName)
                                          .Select(u => u.Id).FirstOrDefault();

            var newOrder = new Orders() { Category_Id = categoryId, User_Id = userId, Date = dateOrder, Price = price, Description = description };
            db.Orders.Add(newOrder);
            db.SaveChanges();
        }
    }
}
