using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories;

namespace Shop.WebLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetCategories());
        }
    }
}
