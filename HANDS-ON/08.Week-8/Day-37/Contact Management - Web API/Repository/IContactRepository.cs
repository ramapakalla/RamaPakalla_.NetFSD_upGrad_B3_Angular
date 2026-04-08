using WebApplication11.Models;

namespace WebApplication11.DataAccess
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContacts();

        ContactInfo GetContactById(int id);

        ContactInfo AddContact(ContactInfo contact);

        bool UpdateContact(int id, ContactInfo contact);

        bool DeleteContact(int id);
    }
}