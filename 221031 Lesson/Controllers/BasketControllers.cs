using _221031_Lesson.DAL;
using _221031_Lesson.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace _221031_Lesson.Controllers
{
    public class BasketControllers : Controller
    {
        private readonly AppDbContext _context;

        public BasketControllers(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Add(BasketAddViewModel model)
        {
            List<BasketAddViewModel> basket;
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketAddViewModel>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketAddViewModel>();
            }

            var basketProduct = basket.Find(b => b.Id == model.Id);
            if (basketProduct != null)
            {
                basketProduct.Count++;
            }
            else
            {
                model.Count++;
                basket.Add(model);
            }

            model.Count++;
            var serializedBasket = JsonConvert.SerializeObject(basket);

            Response.Cookies.Append("basket", serializedBasket);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            List<BasketAddViewModel> basket;
            if (Request.Cookies["basket"] == null) return NotFound();

            basket = JsonConvert.DeserializeObject<List<BasketAddViewModel>>(Request.Cookies["basket"]);

            var dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            var basketProduct = basket.Find(b => b.Id == dbProduct.Id);
            if (basketProduct != null)
            {
                basket.Remove(basketProduct);
            }

            var serializedBasket = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("basket", serializedBasket);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = JsonConvert.DeserializeObject<List<BasketAddViewModel>>(Request.Cookies["basket"]);
            return Json(data);

        }

    }

}
