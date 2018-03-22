using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // 1.2. Конкретная команда - DeleteOrder
    class DeleteOrderCommand : ICommand
    {
        HomeBugaltery homeBugaltery;
        string OrderName;
        int index;
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
