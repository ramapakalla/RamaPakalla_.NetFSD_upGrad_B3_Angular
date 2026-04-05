using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication8.Data;
using WebApplication8.Models;
using WebApplication8.Repositories;

namespace WebApplication8.Controllers
{
    [Route("[controller]/[action]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;
        private readonly ApplicationDbContext _context;

        public ContactController(IContactRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public IActionResult ShowContacts()
        {
            return View(_repository.GetAllContacts());
        }

        public IActionResult GetContactById(int id)
        {
            return View(_repository.GetContactById(id));
        }

        public IActionResult AddContact()
        {
            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");

            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repository.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        public IActionResult EditContact(int id)
        {
            var contact = _repository.GetContactById(id);

            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");

            return View(contact);
        }

        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repository.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        public IActionResult DeleteContact(int id)
        {
            var contact = _repository.GetContactById(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
    }
}