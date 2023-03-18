using API.Data;
using API.Models;
using API.Repository.Interface;

namespace API.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _dbContext;

        public ContactRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool CreateContact(ContactModel contact)
        {
            try
            {
                _dbContext.Contact.Add(contact);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ContactModel> GetContacts()
        {
            return _dbContext.Contact.ToList();
        }

        public bool DeleteContact(Guid id)
        {
            try
            {
                ContactModel existingContact = _dbContext.Contact.Find(id);
                if (existingContact != null)
                {
                    _dbContext.Contact.Remove(existingContact);
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }

        public bool UpdateContact(ContactModel contact)
        {
            try
            {
                ContactModel existingContact = _dbContext.Contact.Find(contact.Id);
                if (existingContact != null)
                {
                    existingContact.Name = contact.Name;
                    existingContact.LastName = contact.LastName;
                    existingContact.Phone = contact.Phone;
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}
