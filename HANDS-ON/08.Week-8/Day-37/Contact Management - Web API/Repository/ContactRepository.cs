using WebApplication11.Models;

namespace WebApplication11.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Ravi",
                LastName = "Kumar",
                EmailId = "ravi.kumar@gmail.com",
                MobileNo = 9876543210,
                Designation = "Software Engineer",
                CompanyId = 1,
                DepartmentId = 1
            },

            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Anita",
                LastName = "Sharma",
                EmailId = "anita.sharma@gmail.com",
                MobileNo = 9876541111,
                Designation = "HR Manager",
                CompanyId = 1,
                DepartmentId = 2
            },

            new ContactInfo
            {
                ContactId = 3,
                FirstName = "Rahul",
                LastName = "Reddy",
                EmailId = "rahul.reddy@gmail.com",
                MobileNo = 9876542222,
                Designation = "Team Lead",
                CompanyId = 2,
                DepartmentId = 1
            },

            new ContactInfo
            {
                ContactId = 4,
                FirstName = "Sneha",
                LastName = "Patel",
                EmailId = "sneha.patel@gmail.com",
                MobileNo = 9876543333,
                Designation = "QA Engineer",
                CompanyId = 2,
                DepartmentId = 3
            }
        };

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public ContactInfo AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
            return contact;
        }

        public bool UpdateContact(int id, ContactInfo updatedContact)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return false;

            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.EmailId = updatedContact.EmailId;
            contact.MobileNo = updatedContact.MobileNo;
            contact.Designation = updatedContact.Designation;
            contact.CompanyId = updatedContact.CompanyId;
            contact.DepartmentId = updatedContact.DepartmentId;

            return true;
        }

        public bool DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return false;

            contacts.Remove(contact);
            return true;
        }
    }
}