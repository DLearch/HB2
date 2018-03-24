using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // 1.4. Конкретная команда - ChangeCategory
    public class ChangeCurentUserCommand : ICommand
    {
        HomeBugaltery homeBugaltery;

        int curentUserId;

        string newEmail;
        string newName;
        string newPass;
        int familyId;

        public ChangeCurentUserCommand(HomeBugaltery homeBugaltery, int curentUserId, string newEmail,  string newName,  string newPass, int familyId)
        {
            this.homeBugaltery = homeBugaltery;

            this.curentUserId = curentUserId;

            this.newEmail = newEmail;
            this.newName = newName;
            this.newPass = newPass;
            this.familyId = familyId;
        } 

        public void Execute()
        {
            homeBugaltery.changeDataCurentUser(curentUserId, newEmail, newName, newPass, familyId);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
