using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Serv : IContract
    {   
        MarketEntities db;

        #region User

        Users user;

        public bool UserIsLoggedIn
        {
            get
            {
                if (user == null)
                {
                    error = "Користувач не аутентифікований.";
                    return false;
                }
                else
                    return true;
            }
        }

        #endregion

        #region Error

        string error;

        public string GetLastError()
        {
            return error;
        }

        #endregion

        public Serv()
        {
            db = new MarketEntities();
            user = null;
            error = "Помилки відсутні.";
        }

        #region Users

        public bool Authentication(string email, string password)
        {
            if(!db.Users.Any(u => u.Email == email && u.Password == password))
            {
                error = "Неправильний Email або пароль.";
                return false;
            }

            user = db.Users.DefaultIfEmpty(null).FirstOrDefault(u => u.Email == email && u.Password == password);
            return true;
        }

        public bool Registration(string name, string email, string password)
        {
            if (db.Users.Any(u => u.Email == email))
            {
                error = "Користувач з таким Email вже існує.";
                return false;
            }

            if(string.IsNullOrEmpty(name))
            {
                error = "Ім'я порожнє.";
                return false;
            }
            if (string.IsNullOrEmpty(email))
            {
                error = "Email порожній.";
                return false;
            }

            if (!CheckPassword(password))
                return false;

            db.Users.Add(new Users() { Email = email, Password = password });

            db.SaveChanges();

            user = db.Users.First(u => u.Email == email);

            db.FamilyMembers.Add(new FamilyMembers() { Name = name, User_Id = user.Id });
            db.Categories.Add(new Categories() { Name = "Зарплата", User_Id = user.Id, Type = true });
            db.Categories.Add(new Categories() { Name = "Їжа", User_Id = user.Id, Type = false });
            db.Categories.Add(new Categories() { Name = "Взуття", User_Id = user.Id, Type = false });

            db.SaveChanges();

            return true;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (!UserIsLoggedIn)
                return false;

            if(user.Password != oldPassword)
            {
                error = "Невірний пароль.";
                return false;
            }

            if (!CheckPassword(newPassword))
                return false;

            user.Password = newPassword;
            db.SaveChanges();
            return true;
        }

        public void SignOut()
        {
            user = null;
            return;
        }

        bool CheckPassword(string password)
        {
            if (password.Length < 4)
            {
                error = "Занадто короткий пароль.";
                return false;
            }

            if (password.Length > 20)
            {
                error = "Занадто довгий пароль.";
                return false;
            }

            return true;
        }

        #endregion

        #region Categories

        public List<Category> GetListCategories()
        {
            if (!UserIsLoggedIn)
                return null;

            return db.Categories.AsEnumerable()
                                .Where(c => c.Users == user)
                                .Select(c => new Category()
                                {
                                    Id = c.Id,
                                    UserId = c.User_Id,
                                    Name = c.Name,
                                    Type = c.Type
                                })
                                .ToList();
        }

        public bool AddCategory(Category category)
        {
            if (!UserIsLoggedIn)
                return false;

            if (string.IsNullOrEmpty(category.Name))
            {
                error = "Ім'я категорії порожнє.";
                return false;
            }

            if (db.Categories.Any(c => c.Name == category.Name))
            {
                error = "Категорія з таким ім'ям вже існує.";
                return false;
            }

            db.Categories.Add(new Categories() {
                Name = category.Name,
                Type = category.Type,
                User_Id = user.Id
            });

            db.SaveChanges();

            return true;
        }

        public bool EditCategory(Category category)
        {
            if (!UserIsLoggedIn)
                return false;

            if (db.Categories.Where(c => c.Name == category.Name).Count() > 1)
            {
                error = "Категорія з таким ім'ям вже існує.";
                return false;
            }

            var categoryToChange = db.Categories.FirstOrDefault(c => c.Id == category.Id);

            if (categoryToChange == null)
            {
                error = "Категорію не знайдено.";
                return false;
            }

            categoryToChange.Name = category.Name;
            categoryToChange.Type = category.Type;
            db.SaveChanges();

            return true;
        }

        public bool RemoveCategory(int id)
        {
            if (!UserIsLoggedIn)
                return false;

            if (db.Orders.Any(o => o.Category_Id == id))
            {
                error = "Не можна видалити категорію, так як вона вже використовується.";
                return false;
            }

            if (!db.Categories.Any(c => c.Id == id))
            {
                error = "Категорію не знайдено.";
                return false;
            }

            db.Categories.Remove(db.Categories.FirstOrDefault(c => c.Id == id));
            db.SaveChanges();

            return true;
        }

        #endregion

        #region FamilyMembers

        public List<FamilyMember> GetListFamilyMembers()
        {
            if (!UserIsLoggedIn)
                return null;

            return db.FamilyMembers.AsEnumerable()
                                   .Where(fm => fm.Users == user)
                                   .Select(fm => new FamilyMember() {
                                       Id = fm.Id,
                                       Name = fm.Name,
                                       UserId = user.Id
                                   })
                                   .ToList();
        }

        public bool AddFamilyMember(string name)
        {
            if (!UserIsLoggedIn)
                return false;

            if (string.IsNullOrEmpty(name))
            {
                error = "Ім'я користувача порожнє.";
                return false;
            }

            if(db.FamilyMembers.Any(fm => fm.Name == name))
            {
                error = "Користувач з таким ім'ям вже існує.";
                return false;
            }

            db.FamilyMembers.Add(new FamilyMembers() {
                Name = name,
                User_Id = user.Id
            });

            db.SaveChanges();

            return true;
        }

        public bool EditFamilyMember(FamilyMember familyMember)
        {
            if (!UserIsLoggedIn)
                return false;

            if (string.IsNullOrEmpty(familyMember.Name))
            {
                error = "Ім'я користувача порожнє.";
                return false;
            }

            if (db.FamilyMembers.Any(fm => fm.Name == familyMember.Name))
            {
                error = "Користувач з таким ім'ям вже існує.";
                return false;
            }

            var familyMemberToChange = db.FamilyMembers.Where(c => c.Id == familyMember.Id).FirstOrDefault();

            if (familyMemberToChange == null)
            {
                error = "Користувача не знайдено.";
                return false;
            }

            familyMemberToChange.Name = familyMember.Name;
            familyMemberToChange.User_Id = user.Id;

            db.SaveChanges();

            return true;
        }

        public bool RemoveFamilyMember(int id)
        {
            if (!UserIsLoggedIn)
                return false;

            if (db.Orders.Any(o => o.FamilyMember_Id == id))
            {
                error = "Не можна видалити користувача, так як він вже використовується.";
                return false;
            }

            if (!db.FamilyMembers.Any(fm => fm.Id == id))
            {
                error = "Користувача не знайдено.";
                return false;
            }

            db.FamilyMembers.Remove(db.FamilyMembers.FirstOrDefault(fm => fm.Id == id));
            db.SaveChanges();

            return true;
        }

        #endregion

        #region Orders

        public List<Order> GetListOrders()
        {
            if (!UserIsLoggedIn)
                return null;

            return db.Orders.AsEnumerable()
                            .Where(o => o.FamilyMembers.Users == user)
                            .Select(o => new Order() {
                                Id = o.Id,
                                CategoryId = o.Category_Id,
                                FamilyMemberId = o.FamilyMember_Id,
                                Date = o.Date,
                                Price = o.Price,
                                Description = o.Description
                            })
                            .ToList();
        }

        public bool AddOrder(Order order)
        {
            if (!UserIsLoggedIn)
                return false;

            db.Orders.Add(new Orders() {
                Category_Id = order.CategoryId,
                Date = order.Date,
                FamilyMember_Id = order.FamilyMemberId,
                Description = order.Description,
                Price = order.Price
            });

            db.SaveChanges();

            return true;
        }

        public bool EditOrder(Order order)
        {
            if (!UserIsLoggedIn)
                return false;
            
            var orderToChange = db.Orders.FirstOrDefault(o => o.Id == order.Id);

            if (orderToChange == null)
            {
                error = "Операцію не знайдено.";
                return false;
            }

            orderToChange.Category_Id = order.CategoryId;
            orderToChange.FamilyMember_Id = order.FamilyMemberId;
            orderToChange.Date = order.Date;
            orderToChange.Price = order.Price;
            orderToChange.Description = order.Description;

            db.SaveChanges();

            return true;
        }

        public bool RemoveOrder(int id)
        {
            if (!UserIsLoggedIn)
                return false;

            if (!db.FamilyMembers.Any(o => o.Id == id))
            {
                error = "Запис не знайдено.";
                return false;
            }

            db.Orders.Remove(db.Orders.FirstOrDefault(o => o.Id == id));
            db.SaveChanges();

            return true;
        }
        
        #endregion

    }
}
