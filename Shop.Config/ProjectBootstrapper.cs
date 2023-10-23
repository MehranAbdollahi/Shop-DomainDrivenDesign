using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Context;

namespace Shop.Config
{
    public class ProjectBootstrapper
    {

        public static void Init(IServiceCollection services)
        {
            services.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer("Server=.;DataBase=ShopDB;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True");
                option.UseSqlServer(b => b.MigrationsAssembly("Shop.WebLayer"));
            });
        }

    }
}