using Domain.Models.Movementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Moviment
{
    public interface IMovementService
    {
        Task<int> GetCurrentStockAsync(int productId);
        Task<List<Movement>> GetMovementsAsync(int productId);
        Task AddMovementAsync(Movement movement);
    }
}
