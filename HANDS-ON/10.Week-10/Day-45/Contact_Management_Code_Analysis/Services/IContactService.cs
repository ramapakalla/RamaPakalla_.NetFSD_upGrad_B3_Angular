using ContactManagementCodeAnalysis.Models;

namespace ContactManagementCodeAnalysis.Services
{
    public interface IContactService
    {
        void AddContact(Contact contact);

        Contact GetContactById(int id);

        void UpdateContact(int id, Contact contact);

        void DeleteContact(int id);

        List<Contact> GetAllContacts();
    }
}
