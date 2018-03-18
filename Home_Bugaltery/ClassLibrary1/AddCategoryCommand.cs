using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class AddCategoryCommand : ICommand
    {
        HomeBugaltery homeBugaltery;
        string categoryName;
        string price;
        string description;

        public AddCategoryCommand(HomeBugaltery homeBugaltery, string categoryName, string price, string description)
        {
            this.homeBugaltery = homeBugaltery;
            this.categoryName = categoryName;
            this.price = price;
            this.description = description;
        }
        public void Execute()
        {
            homeBugaltery.addCategory(categoryName);
            homeBugaltery.validateLocalData();
        }



        public void Undo()
        {
            //Will be implemented if will be needed
        }
    }
}
