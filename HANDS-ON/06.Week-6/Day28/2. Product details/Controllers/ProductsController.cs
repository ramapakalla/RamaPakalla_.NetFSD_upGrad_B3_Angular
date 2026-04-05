using Microsoft.AspNetCore.Mvc;
using MyFirstMvcApp.Models;

namespace MyFirstMvcApp.Controllers
{
    public class ProductsController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product{ProductId=1, ProductName="Laptop", Price=50000, Category="Electronics"},
            new Product{ProductId=2, ProductName="Phone", Price=20000, Category="Electronics"},
            new Product{ProductId=3, ProductName="Shoes", Price=3000, Category="Fashion"}
        };

       
        public IActionResult Index()
        {
            return View(products);
        }

       
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            return View(product);
        }
    }
}
