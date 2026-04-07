using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication8.Models;
using WebApplication8.Repository;

namespace WebApplication8.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public IActionResult ShowContacts()
        {
            var contacts = _repository.GetAllContacts();
            return View(contacts);
        }

        [HttpGet("Details/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _repository.GetContactById(id);
            return View(contact);
        }

        [HttpGet("Add")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = new SelectList(_repository.GetCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_repository.GetDepartments(), "DepartmentId", "DepartmentName");

            return View();
        }

        [HttpPost("Add")]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repository.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("Edit/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _repository.GetContactById(id);

            ViewBag.Companies = new SelectList(
                _repository.GetCompanies(), "CompanyId", "CompanyName", contact.CompanyId);

            ViewBag.Departments = new SelectList(
                _repository.GetDepartments(), "DepartmentId", "DepartmentName", contact.DepartmentId);

            return View(contact);
        }

        [HttpPost("Edit")]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repository.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("Delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repository.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }

        [HttpPost("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
       

    }
}