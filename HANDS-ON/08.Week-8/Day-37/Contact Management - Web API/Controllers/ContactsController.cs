using Microsoft.AspNetCore.Mvc;
using WebApplication11.DataAccess;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;
        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repository.AddContact(contact);
            return Ok( new {contact, status= "New contact  successfully added to server..!" } );
        }


        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(_repository.GetAllContacts());
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return NotFound("Requested contact does not exists");
            }
            else
            {
                return Ok(contact);

            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id,ContactInfo contact)
        {
            var oldcontact = _repository.GetContactById(id);
            if (contact == null)
            {
                return NotFound("Requested contact does not exists");
            }
            else
            {
                oldcontact.FirstName = contact.FirstName;
                oldcontact.LastName = contact.LastName;
                oldcontact.EmailId = contact.EmailId;
                oldcontact.MobileNo = contact.MobileNo;
                oldcontact.Designation = contact.Designation;
                oldcontact.CompanyId = contact.CompanyId;
                oldcontact.DepartmentId = contact.DepartmentId;
                return Ok(new { updatedContact = oldcontact, status = "Contact details are updated successfully in server..!" });

            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return NotFound("Requested contact does not exists");
            }
            else
            {
                _repository.DeleteContact(id);
                
                return Ok(new { contact, status = "Contact details are deleted successfully in server..!" });

            }
        }



        }
}