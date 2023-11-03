using Shop.Application.Categories.DTOs;
using Shop.Application.Utilities;

namespace Shop.Application.Categories;

public interface ICategoryService
{
    OperationResult AddCategory(AddCategoryDto command);
    OperationResult EditCategory(EditCategoryDto command);
    CategoryDto GetCategoryById(long categoryId);
    List<CategoryDto> GetCategories();
}