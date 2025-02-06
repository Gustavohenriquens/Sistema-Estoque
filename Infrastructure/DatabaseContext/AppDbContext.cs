using Domain.Models.Categories;
using Domain.Models.Movementation;
using Domain.Models.Products;
using Domain.Models.Stocks;
using Domain.Models.Suppliers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Movement> Movements { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configuração para uso em tempo de design
                optionsBuilder.UseSqlServer("Server=DESKTOP-9DV2CSG\\SQL_GUSTAVO;Database=SistemaEstoque;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
