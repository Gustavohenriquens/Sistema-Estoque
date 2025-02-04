
using Domain.Interfaces.StockRepository;
using Domain.Models.Stocks;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Stocks
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;
        public StockRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Stock>> GetItemsAsync()
        {
            return await _context.Stocks
                .ToListAsync();
        }

        public async Task<Stock> GetByIdAsync(int? id)
        {
            return await _context.Stocks
                .Include(p => p.Products)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return stock;            
        }

        public async Task<Stock> RemoveAsync(Stock stock)
        { 
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock> UpdateAsync(Stock stock)
        {
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
