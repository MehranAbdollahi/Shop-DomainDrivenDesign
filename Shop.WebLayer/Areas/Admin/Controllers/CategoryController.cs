using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories;
using Shop.Application.Categories.DTOs;
using Shop.Application.Utilities;
using Shop.WebLayer.Areas.Admin.Models.Categories;

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
        [Route("/admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId)
        {
            return View();
        }

        [HttpPost("/admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId, CreateCategoryViewModel createViewModel)
        {
            createViewModel.ParentId = parentId;
            var result = _categoryService.AddCategory(createViewModel.MapToDto());

            //return RedirectAndShowAlert(result, RedirectToAction("Index"));
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return RedirectToAction("Index");

            var model = new EditCategoryViewModel()
            {
                Title = category.Title,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryViewModel editModel)
        {
            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Title = editModel.Title,
                Id = id
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(editModel.Title), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }


        //public IActionResult GetChildCategories(int parentId)
        //{
        //    var categoy = _categoryService.GetChildCategories(parentId);

        //    return new JsonResult(categoy);
        //}
    }
}
