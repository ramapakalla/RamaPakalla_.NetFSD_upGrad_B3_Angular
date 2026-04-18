using CategoryService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class CategoryController : ControllerBase
    {
        private readonly CategoryDbContext _context;

        public CategoryController(CategoryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Categories.ToList());
        }

      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

   
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

      
        [HttpPut("{id}")]
        public IActionResult Update(int id, Category updated)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            category.CategoryName = updated.CategoryName;
            category.Description = updated.Description;

            _context.SaveChanges();
            return Ok(category);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Deleted successfully");
        }
    }
}