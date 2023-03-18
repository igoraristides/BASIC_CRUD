using API.Models;

namespace API.Repository.Interface
{
    public interface IContactRepository
    {
        bool CreateContact(ContactModel contact);

        List<ContactModel> GetContacts();

        bool UpdateContact(ContactModel contact);

        bool DeleteContact(Guid Id);

    }
}
