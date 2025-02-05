using Domain.Interfaces.CategoryRepository;
using Domain.Interfaces.ProductRepository;
using Infrastructure.DatabaseContext;
using Infrastructure.Repositories.Categories;
using Infrastructure.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService
             (this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(
                o => o.UseSqlServer(config.GetConnectionString("DefaultConnection")));


            #region AddScoped  

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            #endregion



            return services;
        }
    }
}
