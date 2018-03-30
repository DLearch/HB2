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
            HomeBugaltery homeBugaltery = HomeBugaltery.getInstance();

           // homeBugaltery.addCategory("Подарунок", true);

            Assert.AreEqual(13, homeBugaltery.ListCategories.Count);
        }

        //Bisnes Logic
        [Test]
        public static void addUser()
        {
            //MarketEntities dbLocal = new MarketEntities("new Connection String!!!");
            //BisnesLogic bisnesLogic = new BisnesLogic(dbLocal);
            HomeBugaltery homeBugaltery = HomeBugaltery.getInstance();
            var listUser = homeBugaltery.ListUsers;

             //bisnesLogic.addNewUser("em@", "Emma", "1111", 2);          

            Assert.AreEqual(5, listUser);
        }

        [Test]
        public static void getListOrders()
        {
            //MarketEntities dbLocal = new MarketEntities("new Connection String!!!");
            //BisnesLogic bisnesLogic = new BisnesLogic(dbLocal);

            //var listUser = bisnesLogic.getAllOrders().Count;
            HomeBugaltery homeBugaltery = HomeBugaltery.getInstance();

            Assert.AreEqual(11, homeBugaltery.ListOrders.Count);
        }

        [Test]
        public static void addOrder()
        {
            HomeBugaltery homeBugaltery = HomeBugaltery.getInstance();

            // homeBugaltery.addOrder("Зарплата", "Руслан", 2017-09-10, 350, 1);

            Assert.AreEqual(13, homeBugaltery.ListCategories.Count);
        }


        [Test]
        public static void getListUser()
        {
           
            HomeBugaltery homeBugaltery = HomeBugaltery.getInstance();

            Assert.AreEqual(5, homeBugaltery.ListUsers.Count);
        }

        [Test]
        public static void getListCategory()
        {

            HomeBugaltery homeBugaltery = HomeBugaltery.getInstance();

            Assert.AreEqual(13, homeBugaltery.ListCategories.Count);
        }

        [Test]
        public static void changeCurentUser()
        {
            HomeBugaltery homeBugaltery = HomeBugaltery.getInstance();

            Assert.AreEqual(13, homeBugaltery.ListCategories.Count);
        }

    }
}
