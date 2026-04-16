using ContactService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _context;

        public ContactController(ContactDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetAll()
        {
            return Ok(_context.Contacts.ToList());
        }

     
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetById(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Contact updated)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();

            contact.Name = updated.Name;
            contact.Email = updated.Email;
            contact.Phone = updated.Phone;
            contact.CategoryId = updated.CategoryId;

            _context.SaveChanges();
            return Ok(contact);
        }

       
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("Deleted successfully");
        }
    }
}