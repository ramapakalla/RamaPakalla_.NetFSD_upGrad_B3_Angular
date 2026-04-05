using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Course_System.Data;
using Student_Course_System.Models;
using System.Diagnostics;

namespace Student_Course_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Students() {
            var stds = _context.Students.Include(s => s.Course).ToList();
            return View(stds);
        }

        public IActionResult Courses()
        {
            var crses = _context.Courses.Include(c => c.Students).ToList();
            return View(crses);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
