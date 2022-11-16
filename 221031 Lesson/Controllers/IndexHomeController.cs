using Microsoft.AspNetCore.Mvc;

namespace _221031_Lesson.Controllers
{
    public class IndexHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
