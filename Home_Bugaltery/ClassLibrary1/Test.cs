using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [TestFixture]
    public class Test
    {

        [Test]
        public static void addCategory()
        {
            HomeBugaltery homeBugaltery = new HomeBugaltery();

           // homeBugaltery.addCategory("Подарунок", true);

            Assert.AreEqual(13, homeBugaltery.ListCategories.Count);
        }

        //Bisnes Logic
        [Test]
        public static void addUser()
        {
            //MarketEntities dbLocal = new MarketEntities("new Connection String!!!");
            //BisnesLogic bisnesLogic = new BisnesLogic(dbLocal);
            //var listUser = bisnesLogic.getAllUsers();

            // bisnesLogic.addNewUser("em@", "Emma", "1111", 2);
            HomeBugaltery homeBugaltery = new HomeBugaltery();           

            Assert.AreEqual(5, homeBugaltery.ListUsers.Count());
        }

        [Test]
        public static void getListOrders()
        {
            //MarketEntities dbLocal = new MarketEntities("new Connection String!!!");
            //BisnesLogic bisnesLogic = new BisnesLogic(dbLocal);

            //var listUser = bisnesLogic.getAllOrders().Count;
            HomeBugaltery homeBugaltery = new HomeBugaltery();

            Assert.AreEqual(11, homeBugaltery.ListOrders.Count);
        }

        [Test]
        public static void addOrder()
        {
            HomeBugaltery homeBugaltery = new HomeBugaltery();

            // homeBugaltery.addOrder("Зарплата", "Руслан", 2017-09-10, 350, 1);

            Assert.AreEqual(13, homeBugaltery.ListCategories.Count);
        }


        [Test]
        public static void getListUser()
        {
           
            HomeBugaltery homeBugaltery = new HomeBugaltery();

            Assert.AreEqual(5, homeBugaltery.ListUsers.Count);
        }

        [Test]
        public static void getListCategory()
        {

            HomeBugaltery homeBugaltery = new HomeBugaltery();

            Assert.AreEqual(13, homeBugaltery.ListCategories.Count);
        }

        [Test]
        public static void changeCurentUser()
        {
            HomeBugaltery homeBugaltery = new HomeBugaltery();

            Assert.AreEqual(13, homeBugaltery.ListCategories.Count);
        }

    }
}
