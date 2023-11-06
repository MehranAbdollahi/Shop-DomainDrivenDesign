using Shop.Application.Categories.DTOs;
using Shop.Application.Utilities;

namespace Shop.Application.Categories;

public interface ICategoryService
{
    OperationResult AddCategory(AddCategoryDto command);
    OperationResult EditCategory(EditCategoryDto command);
    OperationResult DeleteCategory(long categoryId);
    CategoryDto GetCategoryById(long categoryId);
    List<CategoryDto> GetCategories();
}