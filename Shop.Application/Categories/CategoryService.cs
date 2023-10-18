using Shop.Domain.CategoryAgg;
using Shop.Domain.Shared;
using Shop.Application.Categories.DTOs;
using Shop.Domain.CategoryAgg.Repository;

namespace Shop.Application.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public void AddCategory(AddCategoryDto command)
    {
        _repository.Add(new Category(command.Title,command.SubCategoryId));
        _repository.SaveChanges();
    }

    public void EditCategory(EditCategoryDto command)
    {
        var category = _repository.GetById(command.Id);
        category.Edit(command.Title,command.SubCategoryId);

        _repository.Update(category);
        _repository.SaveChanges();
    }

    public CategoryDto GetCategoryById(long categoryId)
    {
        var category = _repository.GetById(categoryId);
        return new CategoryDto()
        {
            Id = categoryId,
            Title = category.Title,
            SubCategoryId = category.SubCategoryId
        };
    }

    public List<CategoryDto> GetCategories()
    {
        return _repository.GetList().Select(category => new CategoryDto()
        {
            Id = category.Id,
            Title = category.Title,
            SubCategoryId = category.SubCategoryId
        }).ToList();

    }
}