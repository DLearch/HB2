using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // 1.4. Конкретная команда - ChangeOrder
    public class ChangeOrderCommand : ICommand
    {
        HomeBugaltery homeBugaltery;
        
        int curentOrderId;
        string categoryName;
        string userName; DateTime dateOrder;
        decimal price;
        string description;

        public ChangeOrderCommand(HomeBugaltery homeBugaltery,int curentOrderId, string categoryName, string userName, DateTime dateOrder, decimal price, string description)
        {
            this.homeBugaltery = homeBugaltery;

            this.curentOrderId = curentOrderId;

            this.categoryName = categoryName;
            this.userName = userName;
            this.dateOrder = dateOrder;
            this.price = price;
            this.description = description;
        }
        public void Execute()
        {
            homeBugaltery.changeOrder(curentOrderId, categoryName, userName, dateOrder, price, description);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
