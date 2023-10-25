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
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public Task<List<ProductDto>> GetProducts()
        {

            return Task.FromResult(_productService.GetProducts());
        }
        [HttpGet("{productId}")]
        public Task<ProductDto> GetOneProductById([FromRoute] long productId)
        {

            return Task.FromResult(_productService.GetProductById(productId));
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts([FromForm] AddProductDto command)
        {

            var res = _productService.AddProduct(command);
            var url = Url.Action(nameof(GetOneProductById), "Product", new { productId = res }, Request.Scheme);
            return Created(url, res);
        }

        [HttpPost("Images")]
        public async Task<IActionResult> AddProductImage(AddProductDto command)
        {

            //
            return Ok();
        }

        [HttpPut]
        public void EditProducts(EditProductDto command)
        {
            _productService.EditProduct(command);

        }

        [HttpDelete]
        public void DeleteProducts(long productId)
        {
            //
        }
    }
}
