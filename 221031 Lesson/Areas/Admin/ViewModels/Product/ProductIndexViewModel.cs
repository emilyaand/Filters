using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace _221031_Lesson.Areas.Admin.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        public List<Models.Product>Products { get; set; }
        #region Filter
        public List<SelectListItem> Categories { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        [Display(Name = "Minimum price")]
        public double? MinPrice { get; set; }
        [Display(Name = "Maximum price")]
        public double MaxPrice { get; set; }
        [Display(Name = "Minimum quantity")]
        public int? MinQuantity { get; set; }

        #endregion
    }
}
