using Shop.Application.Products.DTOs;

namespace Shop.Application.Products;

public interface IProductService
{
    void AddProduct(AddProductDto command);
    void EditProduct(EditProductDto command);
    CategoryDto GetProductById(long productId);
    List<CategoryDto> GetProducts();
}