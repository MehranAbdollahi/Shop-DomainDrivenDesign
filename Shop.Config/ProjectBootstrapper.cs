using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Categories;
using Shop.Application.Orders.Services;
using Shop.Application.Orders;
using Shop.Application.Products;
using Shop.Contracts;
using Shop.Domain.OrderAgg.Services;
using Shop.Domain.Orders.Repository;
using Shop.Domain.ProductAgg;
using Shop.Domain.Products;
using Shop.Infrastructure;
using Shop.Infrastructure.EF.Core.Products;
using Shop.Infrastructure.Orders;
using Shop.Domain.CategoryAgg.Repository;

namespace Shop.Config
{
    public class ProjectBootstrapper
    {

        public static void Init(IServiceCollection services)
        {

            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderDomainService, OrderDomainService>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddScoped<ISmsService, SmsService>();
        }

    }
}