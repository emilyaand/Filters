using _221031_Lesson.Areas.Admin.ViewModels;
using _221031_Lesson.Areas.Admin.ViewModels.Category;
using _221031_Lesson.DAL;
using _221031_Lesson.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _221031_Lesson.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = new CategoryIndexViewModel()
            {
                categories = await _appDbContext.Categories.ToListAsync()
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateViewModel categoryCreateViewModel)
        { 
            if(!ModelState.IsValid) return View(categoryCreateViewModel);
            var category = new Category() { 
                Name=categoryCreateViewModel.Name 
            };
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);
            if (category == null) return NotFound();
             _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var category = await _appDbContext.Categories.FindAsync(Id);
            if(category == null) return NotFound();
            var model = new CategoryUpdateViewModel { Name = category.Name };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateViewModel categoryUpdateViewModel,int Id)
        {
            var category = await _appDbContext.Categories.FindAsync(Id);
            if (category == null) return NotFound();
            if (!ModelState.IsValid) return View(categoryUpdateViewModel);
            category.Name = categoryUpdateViewModel.Name;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var category = await _appDbContext.Categories.FindAsync(Id);
            if (category == null) return NotFound();

            var model = new CategoryDetailsViewModel { Name = category.Name };

            return View(model);
        }
    }
}
