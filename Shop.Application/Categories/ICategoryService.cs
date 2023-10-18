using Shop.Application.Categories.DTOs;

namespace Shop.Application.Categories;

public interface ICategoryService
{
    void AddCategory(AddCategoryDto command);
    void EditCategory(EditCategoryDto command);
    CategoryDto GetCategoryById(long categoryId);
    List<CategoryDto> GetCategories();
}