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

        static private HomeBugalteryAction instance = null;

        static public HomeBugalteryAction getInstance()
        {
            if (instance == null)
                instance = new HomeBugalteryAction();

            return instance;
        }

        ICommand[] commands;
        Stack<int> doneActionsIndexes;


        public HomeBugalteryAction()
        {
            commands = new ICommand[10];
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
