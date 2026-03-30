using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        static List<ContactInfo> contacts = new List<ContactInfo>
        {
    new ContactInfo
    {
        ContactId = 1,
        FirstName = "Ravi",
        LastName = "Kumar",
        CompanyName = "ABC Infotech",
        EmailId = "ravi.kumar@abc.com",
        MobileNo = 9876543210,
        Designation = "Manager"
    },

    new ContactInfo
    {
        ContactId = 2,
        FirstName = "Anita",
        LastName = "Sharma",
        CompanyName = "Tech Solutions",
        EmailId = "anita.sharma@tech.com",
        MobileNo = 9123456780,
        Designation = "Software Engineer"
    },

    new ContactInfo
    {
        ContactId = 3,
        FirstName = "Rahul",
        LastName = "Verma",
        CompanyName = "Global Systems",
        EmailId = "rahul.verma@global.com",
        MobileNo = 9988776655,
        Designation = "Team Lead"
    },

    new ContactInfo
    {
        ContactId = 4,
        FirstName = "Priya",
        LastName = "Reddy",
        CompanyName = "Innovatech",
        EmailId = "priya.reddy@innovatech.com",
        MobileNo = 9012345678,
        Designation = "HR Manager"
    }
};


        public ActionResult ShowContacts()
        {
            return View(contacts);
        }

        public ActionResult GetContactById(int id)
        {
            ContactInfo contactInfoObj = contacts.FirstOrDefault(item => item.ContactId == id);
            return View(contactInfoObj);
        }

        public ActionResult AddContact()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(contactInfo);
                return RedirectToAction("ShowContacts");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid data. Some of the validations are failed.";
                return View(contactInfo);
            }
           
        }


    }
}
