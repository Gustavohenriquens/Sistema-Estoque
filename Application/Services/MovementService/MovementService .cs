using Application.Interfaces.Moviment;
using Domain.Interfaces.MovementationRepository;
using Domain.Interfaces.ProductRepository;
using Domain.Models.Movementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MovementService
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IProductRepository _productRepository;
        public MovementService(IMovementRepository movementRepository, IProductRepository productRepository)
        {
            _movementRepository = movementRepository;
            _productRepository = productRepository;
        }


        public async Task<int> GetCurrentStockAsync(int productId)
        {
            return await _movementRepository.GetCurrentStockAsync(productId);
        }

        public async Task<List<Movement>> GetMovementsAsync(int productId)
        {
            return await _movementRepository.GetMovementsAsync(productId);
        }

        public async Task AddMovementAsync(Movement movement)
        {
            var product = await _productRepository.GetByIdAsync(movement.ProductId);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            if (movement.Type == "Exit" && product.Amount < movement.Quantity)
                throw new InvalidOperationException("Insufficient stock!");

            // Registrar data e hora corretamente para todas as movimentações
            if (movement.Timestamp == default(DateTime))
                movement.Timestamp = DateTime.Now;  

            // Atualiza o estoque
            if (movement.Type == "Entry")
                product.Amount += movement.Quantity;
            else if (movement.Type == "Exit")
                product.Amount -= movement.Quantity;

            await _productRepository.UpdateAsync(product); // Atualiza o estoque no banco
            await _movementRepository.AddMovementAsync(movement); // Salva a movimentação
        }

    }
}
