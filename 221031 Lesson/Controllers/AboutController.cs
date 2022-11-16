using Microsoft.AspNetCore.Mvc;

namespace _221031_Lesson.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
