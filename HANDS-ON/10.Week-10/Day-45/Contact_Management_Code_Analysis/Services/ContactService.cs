using ContactManagementCodeAnalysis.Models;

namespace ContactManagementCodeAnalysis.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new List<Contact>()
    {
    new Contact { Id = 1, Name = "Rama", Email = "rama@gmail.com", Phone = "9999999999" },
    new Contact { Id = 2, Name = "John", Email = "john@gmail.com", Phone = "8888888888" },
    new Contact { Id = 3, Name = "Sara", Email = "sara@gmail.com", Phone = "7777777777" }
     };

        public void AddContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _contacts.Add(contact);
        }
     public Contact GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(x=>x.Id == id);
            if(contact == null)
                throw new ArgumentNullException(nameof(contact));

            return contact;

        }
        public void UpdateContact(int id, Contact updatedContact)
        {
           if(updatedContact==null) 
                throw new ArgumentNullException(nameof(updatedContact));

           var existingContact = GetContactById(id);

            if (updatedContact != null)
            {
                updatedContact.Name = existingContact.Name;
                updatedContact.Email = existingContact.Email;
                updatedContact.Phone = existingContact.Phone;
            }
        }

        public void DeleteContact(int id) {
            var contact = GetContactById(id);

            if (contact == null)
                throw new InvalidOperationException("Contact not found");

            _contacts.Remove(contact);

        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;

        }
    }
}
