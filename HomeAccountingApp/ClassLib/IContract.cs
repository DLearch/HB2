using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ClassLib
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        bool Authentication(string email, string password);
        [OperationContract]
        bool Registration(string name, string email, string password);
        [OperationContract]
        bool ChangePassword(string oldPassword, string newPassword);
        [OperationContract]
        void SignOut();

        [OperationContract]
        List<Category> GetListCategories();
        [OperationContract]
        bool AddCategory(Category category);
        [OperationContract]
        bool EditCategory(Category category);
        [OperationContract]
        bool RemoveCategory(int id);

        [OperationContract]
        List<FamilyMember> GetListFamilyMembers();
        [OperationContract]
        bool AddFamilyMember(string name);
        [OperationContract]
        bool EditFamilyMember(FamilyMember familyMember);
        [OperationContract]
        bool RemoveFamilyMember(int id);

        [OperationContract]
        List<Order> GetListOrders();
        [OperationContract]
        bool AddOrder(Order order);
        [OperationContract]
        bool EditOrder(Order order);
        [OperationContract]
        bool RemoveOrder(int id);

        [OperationContract]
        string GetLastError();
    }
}