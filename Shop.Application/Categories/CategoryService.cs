using Shop.Domain.CategoryAgg;
using Shop.Domain.Shared;
using Shop.Application.Categories.DTOs;
using Shop.Application.Categories.Mappers;
using Shop.Application.Utilities;
using Shop.Domain.CategoryAgg.Repository;

namespace Shop.Application.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public CategoryService()
    {
        
    }

    public OperationResult AddCategory(AddCategoryDto command)
    {
        _repository.Add(new Category(command.Title,command.ParentId));
        _repository.SaveChanges();

        return OperationResult.Success("عملیات با موفقیت انجام شد.");
    }

    public OperationResult EditCategory(EditCategoryDto command)
    {
        var category = _repository.GetById(command.Id);

        if (category == null)
        {
            return OperationResult.NotFound("دسته بندی یافت نشد.");
        }
        category.Edit(command.Title,command.ParentId);

        _repository.Update(category);
        _repository.SaveChanges();

        return OperationResult.Success("عملیات با موفقیت انجام شد.");
    }

    public CategoryDto GetCategoryById(long categoryId)
    {
        var category = _repository.GetById(categoryId);

        return CategoryMapper.Map(category);
    }

    public List<CategoryDto> GetCategories()
    {
        return _repository.GetList().Select(CategoryMapper.Map).ToList();

    }
}