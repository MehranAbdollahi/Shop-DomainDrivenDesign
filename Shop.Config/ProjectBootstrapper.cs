
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Categories;
using Shop.Application.Orders.Services;
using Shop.Application.Orders;
using Shop.Application.Products;
using Shop.Application.Users;
using Shop.Contracts;
using Shop.Domain.OrderAgg.Services;
using Shop.Domain.Orders.Repository;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure;
using Shop.Infrastructure.EF.Core.Products;
using Shop.Infrastructure.EF.Core.Users;
using Shop.Infrastructure.Orders;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.UserAgg;
using Shop.Infrastructure.EF.Core.Categories;

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
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ISmsService, SmsService>();
        }

    }
}