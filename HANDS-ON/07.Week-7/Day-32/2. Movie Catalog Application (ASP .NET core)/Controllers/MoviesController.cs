using Microsoft.AspNetCore.Mvc;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;
        
        public MoviesController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Movie.ToList());
        }

        public IActionResult Details(int id)
        {
            var movieObj = _context.Movie.Find(id);
            return View(movieObj);
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movie.Add(movie);     // Create
                _context.SaveChanges();             // Update to Database
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Movie details.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieObj = _context.Movie.Find(id);
            return View(movieObj);
        }



        [HttpPost]
        public IActionResult Edit(Movie movie)
        {

            if (ModelState.IsValid)
            {
                _context.Movie.Update(movie);     // Create
                _context.SaveChanges();             // Update to Database
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Movie details.";
                return View();
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Movie = _context.Movie.Find(id);
            return View(Movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _context.Movie.Find(id);

            if (prodObj != null)
            {
                _context.Movie.Remove(prodObj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested movie does not exists";
                return View();
            }
        }

    }
}
