
using Domain.Interfaces.MovementationRepository;
using Domain.Models.Movementation;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Movementation
{
    public class MovementRepository : IMovementRepository
    {
        private readonly AppDbContext _context;
        public MovementRepository(AppDbContext context)
        {
            _context = context;   
        }

        public async Task<int> GetCurrentStockAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            return product?.Amount ?? 0;
        }

        public async Task<List<Movement>> GetMovementsAsync(int productId)
        {
            return await _context.Movements
                .Where(m => m.ProductId == productId)
                .OrderByDescending(m => m.Timestamp)
                .ToListAsync();
        }

        public async Task AddMovementAsync(Movement movement)
        {
            await _context.Movements.AddAsync(movement);
            await _context.SaveChangesAsync();
        }

    }
}
