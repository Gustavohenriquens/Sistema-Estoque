using Domain.Interfaces.ProductRepository;
using Domain.Models.Products;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetItemsAsync()
        {
            return await _context.Products
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products
                .Include(c => c.Category)  //O id do produto que eu achar vai vir com o id da categoria para eu saber qual categoria é.
                .Include(p => p.Stock)     
                .Include(p => p.Supplier)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
