using Shop.Domain.OrderAgg.Services;
using Shop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Orders.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IProductRepository _productRepository;

        public OrderDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool IsProductNotExsist(long productId)
        {
            var productIsExsit = _productRepository.IsProductExist(productId);

            return !productIsExsit;
        }
    }
}
