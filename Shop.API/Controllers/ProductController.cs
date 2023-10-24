using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products;
using Shop.Application.Products.DTOs;
using Shop.Domain.Products;

namespace Shop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public void AddProducts(AddProductDto command)
        {

            _productService.AddProduct(command);
        }
        [HttpGet]
        public Task<List<ProductDto>> GetProducts()
        {

            return Task.FromResult(_productService.GetProducts());
        }
        [HttpGet("{productId}")]
        public Task<ProductDto> GetOneProductById(long productId)
        {

            return Task.FromResult(_productService.GetProductById(productId));
        }
    }
}
