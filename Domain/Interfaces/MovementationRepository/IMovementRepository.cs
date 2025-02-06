using Domain.Models.Movementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.MovementationRepository
{
    public interface IMovementRepository
    {
        Task<List<Movement>> GetMovementsAsync(int productId);
        Task<int> GetCurrentStockAsync(int productId);
        Task AddMovementAsync(Movement movement);
    }
}
