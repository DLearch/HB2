using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BisnesLogic
    {
        MarketEntities db;

        public BisnesLogic()
        {
            db = new MarketEntities();

        }

        public List<Users_HB> GetAllUsers()
        {
            var users = db.Users_HB.Select(user => user);

            return users.ToList();
        }

        public List<Categories_HB> GetAllCategory()
        {
            //var result = from i in db.Categories
            //           select i;


            var result = db.Categories_HB.Select(c => c);

            return result.ToList();
        }

        public List<OrdersView> GetAllOrders()
        {

            var result = (from order in db.Orders_HB
                          join category in db.Categories_HB on order.Category_Id equals category.Id
                          join user in db.Users_HB on order.User_Id equals user.Id
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
            var categoryName = db.Categories_HB.FirstOrDefault(categ => categ.Id == index).Name;

            return categoryName;
        }

        public void AddOrder(string categoryName, string userName, DateTime dateOrder, decimal price, string description)
        {
            var categoryId = db.Categories_HB.Where(cat => cat.Name == categoryName)
                                          .Select(x => x.Id).FirstOrDefault();

            var userId = db.Users_HB.Where(user => user.Name == userName)
                                          .Select(u => u.Id).FirstOrDefault();

            var newOrder = new Orders_HB() { Category_Id = categoryId, User_Id = userId, Date = dateOrder, Price = price, Description = description };
            db.Orders_HB.Add(newOrder);
            db.SaveChanges();
        }
    }
}
