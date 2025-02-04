using Application.DTOs.ProductDto;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Product
{
    public interface IProductService
    {
        Task<IList<ProductDTO>> GetAllItemsAsync();
        Task<ProductDTO> GetByIdAsync(int id);
        Task AddAsync(ProductCreateDTO product);
        Task UpdateAsync(ProductUpdateDTO entity);
        Task DeleteAsync(int id);
    }
}
