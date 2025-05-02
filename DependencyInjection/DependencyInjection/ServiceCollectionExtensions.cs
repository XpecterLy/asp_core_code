using Microsoft.EntityFrameworkCore;
using ShopApi.Config;
using ShopApi.Interfaces;
using ShopApi.Models;
using ShopApi.Repository;
using ShopApi.Services;

namespace ShopApi.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddItemServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("shop_db");

            // DbContext
            services.AddDbContext<DbContextShoopDb>(options =>
                options.UseSqlServer(connectionString));

            // Servicios
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
