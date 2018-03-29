using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // 1.4. Конкретная команда - ChangeCategory
    public class ChangeCategoryCommand :ICommand
    {
        HomeBugaltery homeBugaltery;

        int curentCategoryId;
        string newName;
        private bool newType;

        public ChangeCategoryCommand(HomeBugaltery homeBugaltery, int curentCategoryId, string newName, bool newType)
        {
            this.homeBugaltery = homeBugaltery;

            this.curentCategoryId = curentCategoryId;

            this.newName = newName;
            this.newType = newType;
        }

        public void Execute()
        {
            homeBugaltery.changeCategory(curentCategoryId, newName, newType);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
