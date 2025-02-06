using Domain.Interfaces.CategoryRepository;
using Domain.Interfaces.MovementationRepository;
using Domain.Interfaces.ProductRepository;
using Domain.Interfaces.StockRepository;
using Domain.Interfaces.SupplierRepository;
using Infrastructure.DatabaseContext;
using Infrastructure.Repositories.Categories;
using Infrastructure.Repositories.Movementation;
using Infrastructure.Repositories.Products;
using Infrastructure.Repositories.Stocks;
using Infrastructure.Repositories.Suppliers;
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
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();

            #endregion



            return services;
        }
    }
}
