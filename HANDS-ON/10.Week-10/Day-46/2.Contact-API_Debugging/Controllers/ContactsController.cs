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
        private readonly ILogger<ContactsController> _logger;


        public ContactsController(IContactService service, ILogger<ContactsController> logger)
        {
            _service = service;
            _logger = logger;
        }
        
        //Get all conatacts
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Fetching all contacts");
            return Ok(_service.GetAllContacts());
        }

        // Add conatct
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation("Adding new contact: {Name}", contact.Name);

            _service.AddContact(contact);
            return Ok(contact); // return actual data
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _logger.LogInformation("Updating contact with ID: {Id}", id);

                _service.UpdateContact(id, contact);
                return Ok(contact);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }

        // Delete contact
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting contact with ID: {Id}", id);

                _service.DeleteContact(id);
                return Ok("Deleted successfully");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}