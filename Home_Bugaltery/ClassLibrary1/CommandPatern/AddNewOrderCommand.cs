using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // 1.2. Конкретная команда - AddOrder
    public class AddNewOrderCommand : ICommand
    {
        HomeBugaltery homeBugaltery;

        string categoryName;
        string userName; DateTime dateOrder;
        decimal price;
        string description;

        public AddNewOrderCommand(HomeBugaltery homeBugaltery, string categoryName, string userName, DateTime dateOrder, decimal price, string description)
        {
            this.homeBugaltery = homeBugaltery;
            this.categoryName = categoryName;
            this.userName = userName;
            this.dateOrder = dateOrder;
            this.price = price;
            this.description = description;
        }

        public void Execute()
        {
            homeBugaltery.addOrder(categoryName, userName, dateOrder, price, description);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
