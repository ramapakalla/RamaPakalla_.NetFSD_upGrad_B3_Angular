using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(string Name, string Comments, int Rating)
        {
            if (Rating >= 4)
            {
                ViewData["Message"] = "Thank You for your feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            return View("Index");
        }
    }

}
