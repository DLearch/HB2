using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    // 3. Инициатор (менеджер команд)
    // ==============================

    public class HomeBugalteryAction
    {
        ICommand[] commands;
        Stack<int> doneActionsIndexes;


        public HomeBugalteryAction()
        {
            commands = new ICommand[2];
            doneActionsIndexes = new Stack<int>(20);

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new NoCommand();
            }
        }

        public void SetCommand(int actionIndex, ICommand command)
        {
            commands[actionIndex] = command;
        }

        public void DoAction(int actionIndex)
        {
            commands[actionIndex].Execute();
            doneActionsIndexes.Push(actionIndex);
        }

        public void UndoLastAction()
        {
            commands[doneActionsIndexes.Pop()].Undo();
        }


    }
}
