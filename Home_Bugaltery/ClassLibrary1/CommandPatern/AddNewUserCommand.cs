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
        int familyId;

        public AddNewUserCommand(HomeBugaltery homeBugaltery, string email, string name, string password, int familyId)
        {
            this.homeBugaltery = homeBugaltery;
            this.userEmail = email;
            this.userName = name;
            this.userPassword = password;
            this.familyId = familyId;
        }
        public void Execute()
        {
           homeBugaltery.addNewUser(userEmail, userName, userPassword, familyId);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
