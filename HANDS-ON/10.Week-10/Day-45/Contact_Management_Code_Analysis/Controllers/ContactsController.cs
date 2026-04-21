using ContactManagementCodeAnalysis.Models;
using ContactManagementCodeAnalysis.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementCodeAnalysis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }
        
        //Get all conatacts
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllContacts());
        }

        // Add conatct
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.AddContact(contact);
            return Ok(contact); // return actual data
        }

        // Update contact
        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _service.UpdateContact(id, contact);
                return Ok(contact);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete contact
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteContact(id);
                return Ok("Deleted successfully");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}