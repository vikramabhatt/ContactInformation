using ContactInformation.Entity;
using System.Collections.Generic;

namespace ContactInformation.Repository.Interface
{
    public interface IContactRepository
    {
        Contact GetContactInformation(int id);
        List<Contact> GetContactInformation();
        bool IsEmailExist(string emailId);
        int AddContactInformation(Contact contact);
        int EditContactInformation(Contact contact);
        int DeleteContactInformation(int id);
    }
}
