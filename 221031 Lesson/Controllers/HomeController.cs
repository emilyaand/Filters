using _221031_Lesson.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _221031_Lesson.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

        
    }
}