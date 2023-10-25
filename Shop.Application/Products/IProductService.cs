using Shop.Application.Products.DTOs;

namespace Shop.Application.Products;

public interface IProductService
{
    long AddProduct(AddProductDto command);
    void EditProduct(EditProductDto command);
    ProductDto GetProductById(long productId);
    List<ProductDto> GetProducts();
}