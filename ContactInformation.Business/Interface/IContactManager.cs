using ContactInformation.Business.Model;
using System.Collections.Generic;

namespace ContactInformation.Business.Interface
{
    public interface IContactManager
    {
        ContactModel GetContactInformation(int Id);
        IList<ContactModel> GetContactInformation();
        int AddContactInformation(ContactModel contactModel);
        int EditContactInformation(ContactModel contactModel);
        int DeleteContactInformation(int id);
        string ValidateContact(ContactModel contactModel, bool isAdd);
    }
}
