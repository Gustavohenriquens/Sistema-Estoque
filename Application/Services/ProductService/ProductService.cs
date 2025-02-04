using Application.DTOs.ProductDto;
using Application.Interfaces.Product;
using AutoMapper;
using Domain.Interfaces.ProductRepository;
using Domain.Models.Products;

namespace Application.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;   
            _mapper = mapper;
        }

        public async Task<IList<ProductDTO>> GetAllItemsAsync()
        {
            try
            {
                var items = await _productRepository.GetItemsAsync();
                return _mapper.Map<IList<ProductDTO>>(items);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
           var productId = await _productRepository.GetByIdAsync(id);
           return _mapper.Map<ProductDTO>(productId);
        }

        public async Task AddAsync(ProductCreateDTO productDto)
        {
            var productAdd = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productAdd);
        }

        public async Task UpdateAsync(ProductUpdateDTO productDto)
        {
            var productUpdate = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var productDelete = _mapper.Map<Product>(id);
            await _productRepository.RemoveAsync(productDelete);
        }

    }
}
