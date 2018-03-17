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
        public HomeBugalteryAction()
        {
            commands = new ICommand[2];

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new NoCommand();
            }
        }

        public void SetCommand(int number, ICommand command)
        {
            commands[number] = command;
        }

        public void PressButton(int number)
        {
            commands[number].Execute();
        }

        public void PressUndo()
        {

        }


    }
}
