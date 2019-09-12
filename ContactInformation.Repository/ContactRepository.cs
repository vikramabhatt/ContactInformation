using ContactInformation.Entity;
using ContactInformation.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactInformation.Repository
{
    public class ContactRepository : IContactRepository
    {
        public List<Contact> staticContacts = new List<Contact>();

        public ContactRepository()
        {
            staticContacts.Add(new Contact()
            {
                Id = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "firstname1@email.com",
                PhoneNumber = "123456",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                Status = 1 //active
            });

            staticContacts.Add(new Contact()
            {
                Id = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                Email = "firstname2@email.com",
                PhoneNumber = "234567",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                Status = 1 //active
            });

            staticContacts.Add(new Contact()
            {
                Id = 3,
                FirstName = "FirstName3",
                LastName = "LastName3",
                Email = "firstname3@email.com",
                PhoneNumber = "345678",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                Status = 1 //active
            });

            staticContacts.Add(new Contact()
            {
                Id = 4,
                FirstName = "FirstName4",
                LastName = "LastName4",
                Email = "firstname4@email.com",
                PhoneNumber = "456789",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                Status = 1 //active
            });

            staticContacts.Add(new Contact()
            {
                Id = 5,
                FirstName = "FirstName5",
                LastName = "LastName5",
                Email = "firstname5@email.com",
                PhoneNumber = "567890",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                Status = 1 //active
            });
        }

        public Contact GetContactInformation(int id)
        {
            //EF context will be fetching data from SQL Server database. There will be using block around context.

            var contact = staticContacts.Where(x => x.Id == id && x.Status == 1).SingleOrDefault();

            return contact;
        }

        public bool IsEmailExist(string emailId)
        {
            return staticContacts.Where(x => x.Email == emailId).Any();
        }

        public List<Contact> GetContactInformation()
        {
            //EF context will be fetching data from SQL Server database. There will be using block around context.

            var contacts = staticContacts.Where(x => x.Status == 1).OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList();

            return contacts;
        }

        public int AddContactInformation(Contact contact)
        {
            contact.Id = staticContacts.Count + 1;

            staticContacts.Add(contact);

            return contact.Id;
        }

        public int EditContactInformation(Contact contact)
        {
            var index = staticContacts.FindIndex(x => x.Email == contact.Email);

            if (index < 0)
            {
                return -1;
            }

            var contactRecord = staticContacts[index];

            contactRecord.FirstName = contact.FirstName;
            contactRecord.LastName = contact.LastName;
            contactRecord.Email = contact.Email;
            contactRecord.PhoneNumber = contact.PhoneNumber;
            contactRecord.UpdatedBy = contact.UpdatedBy;
            contactRecord.UpdatedOn = contact.UpdatedOn;

            staticContacts[index] = contactRecord;

            return contactRecord.Id;
        }

        public int DeleteContactInformation(int id)
        {
            var index = staticContacts.FindIndex(x => x.Id == id);

            if (index < 0)
            {
                return -1;
            }

            staticContacts.RemoveAt(index);

            return id;
        }
    }
}
