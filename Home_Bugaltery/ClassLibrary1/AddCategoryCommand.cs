using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // 1.3. Конкретная команда - AddCategory
    public class AddCategoryCommand : ICommand
    {
        HomeBugaltery homeBugaltery;
        string categoryName;
        bool type;

        public AddCategoryCommand(HomeBugaltery homeBugaltery, string categoryName, bool type)
        {
            this.homeBugaltery = homeBugaltery;
            this.categoryName = categoryName;
            this.type = type;
        }
        public void Execute()
        {
            homeBugaltery.addCategory(categoryName, type);
        }



        public void Undo()
        {
            //Will be implemented if will be needed
        }
    }
}
