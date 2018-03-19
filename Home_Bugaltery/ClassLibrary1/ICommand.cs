using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // 1. Иерархия команд
    // ==================
    // 1.1. Базовый интерфейс набора команд:

    public interface ICommand
    {
        void Execute();
        void Undo();

    }
}
