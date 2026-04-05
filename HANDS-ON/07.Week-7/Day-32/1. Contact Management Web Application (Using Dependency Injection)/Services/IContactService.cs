using WebApplication5.Models;

namespace WebApplication5.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();

        ContactInfo GetContactById(int id);

        void AddContact(ContactInfo contact);
    }
}
