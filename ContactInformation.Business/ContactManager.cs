using ContactInformation.Business.Interface;
using ContactInformation.Business.Model;
using ContactInformation.Entity;
using ContactInformation.Helper;
using ContactInformation.Repository.Interface;
using System;
using System.Collections.Generic;

namespace ContactInformation.Business
{
    public class ContactManager : IContactManager
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public ContactModel GetContactInformation(int id)
        {
            var contact = _contactRepository.GetContactInformation(id);
            return d2bContact(contact);
        }

        public IList<ContactModel> GetContactInformation()
        {
            var contactModels = new List<ContactModel>();
            var contacts = _contactRepository.GetContactInformation();

            contacts.ForEach(x => { contactModels.Add(d2bContact(x)); });

            return contactModels;
        }

        public int AddContactInformation(ContactModel contactModel)
        {
            var contact = b2dContact(contactModel);
            return _contactRepository.AddContactInformation(contact);
        }

        public int EditContactInformation(ContactModel contactModel)
        {
            var contact = b2dContact(contactModel);
            return _contactRepository.EditContactInformation(contact);
        }

        public int DeleteContactInformation(int id)
        {
            return _contactRepository.DeleteContactInformation(id);
        }

        public string ValidateContact(ContactModel contactModel, bool isAdd)
        {
            if (ValidationHelper.IsValidEmail(contactModel.Email) == false)
            {
                return "Invalid Email.";
            }
            
            if (isAdd && _contactRepository.IsEmailExist(contactModel.Email))
            {
                return "Email already exist.";
            }

            return string.Empty;
        }

        private Contact b2dContact(ContactModel contactModel)
        {
            Contact contact = null;

            if (contactModel != null)
            {
                contact = new Contact()
                {
                    FirstName = contactModel.FirstName,
                    LastName = contactModel.LastName,
                    Email = contactModel.Email,
                    PhoneNumber = contactModel.PhoneNumber,
                    Status = 1 //active
                };

                if (contactModel.Id == 0)
                {
                    contact.CreatedBy = contactModel.LastActionBy;
                    contact.CreatedOn = DateTime.Now;
                }
                else
                {
                    contact.UpdatedBy = contactModel.LastActionBy;
                    contact.UpdatedOn = DateTime.Now;
                }
            }

            return contact;
        }

        private ContactModel d2bContact(Contact contact)
        {
            ContactModel contactModel = null;

            if (contact != null)
            {
                contactModel = new ContactModel()
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Status = contact.Status,
                    LastActionBy = contact.UpdatedBy.HasValue ? contact.UpdatedBy.Value : contact.CreatedBy,
                    LastActionOn = contact.UpdatedOn.HasValue ? contact.UpdatedOn.Value : contact.CreatedOn
                };
            }

            return contactModel;
        }
    }
}
