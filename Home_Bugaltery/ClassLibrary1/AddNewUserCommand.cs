using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // 1.3. Конкретная команда - AddUser
    public class AddNewUserCommand : ICommand
    {
        HomeBugaltery homeBugaltery;
        string userEmail;
        string userName;
        string userPassword;
        public AddNewUserCommand(HomeBugaltery homeBugaltery, string email, string name, string password)
        {
            this.homeBugaltery = homeBugaltery;
            this.userEmail = email;
            this.userName = name;
            this.userPassword = password;
        }
        public void Execute()
        {
           homeBugaltery.addNewUser(userEmail, userName, userPassword);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
