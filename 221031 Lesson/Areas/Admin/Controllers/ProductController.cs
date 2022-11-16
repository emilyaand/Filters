using _221031_Lesson.Areas.Admin.ViewModels.Product;
using _221031_Lesson.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _221031_Lesson.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var Model = new ProductIndexViewModel
            {
                Products = await _appDbContext.Products.ToListAsync()
            };
           return View(Model);
        }
    }
    [HttpGet]
    public async Task<IActionResult> Index(ProductIndexViewModel model)
    {
        var products = FilterProduct(model);

        model = new ProductIndexViewModel
        {
            Products = await products.Include(p => p.Category).ToListAsync(),
            Categories = await _appDbContext.Categories.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            })
            .ToListAsync()
        };
        return View(model);

    }
}
