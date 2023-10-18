using Shop.Domain.Products;
using Shop.Domain.Shared;
using Shop.Application.Products.DTOs;

namespace Shop.Application.Products;

public class CategoryService : IProductService
{
    private readonly IProductRepository _repository;

    public CategoryService(IProductRepository repository)
    {
        _repository = repository;
    }

    public void AddProduct(AddProductDto command)
    {
        _repository.Add(new Product(command.Title,Money.FromTooman(command.Price)));
        _repository.Save();
    }

    public void EditProduct(EditProductDto command)
    {
        var product = _repository.GetById(command.Id);
        product.Edit(command.Title, Money.FromTooman(command.Price));

        _repository.Update(product);
        _repository.Save();
    }

    public CategoryDto GetProductById(long productId)
    {
        var product = _repository.GetById(productId);
        return new CategoryDto()
        {
            Price = product.Money.RialValue,
            Id = productId,
            Title = product.Title
        };
    }

    public List<CategoryDto> GetProducts()
    {
        return _repository.GetList().Select(product => new CategoryDto()
        {
            Price = product.Money.RialValue,
            Id = product.Id,
            Title = product.Title
        }).ToList();

    }
}