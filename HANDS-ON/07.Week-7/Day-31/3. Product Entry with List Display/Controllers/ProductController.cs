using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private static List<Product> productList = new List<Product>();

        [HttpGet("index")]
        public IActionResult Index()
        {
            ViewBag.Products = productList;
            return View();
        }

        [HttpPost("entry")]
        public IActionResult Entry(Product product)
        {
            productList.Add(product);

            return RedirectToAction("Index");
        }
    }
}