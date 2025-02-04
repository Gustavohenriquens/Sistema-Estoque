using Domain.Interfaces.SupplierRepository;
using Domain.Models.Suppliers;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Suppliers
{
    public class SupplierRepository : ISupplierRepository
    {

        private readonly AppDbContext _context;
        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }
            
        public async Task<IEnumerable<Supplier>> GetItemsAsync()
        {
            return await _context.Suppliers
                .ToListAsync();
        }
        public async Task<Supplier> GetByIdAsync(int? id)
        {
            return await _context.Suppliers
                .Include(p => p.Products)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> RemoveAsync(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> UpdateAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

    }
}
