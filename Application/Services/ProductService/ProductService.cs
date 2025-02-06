using Application.DTOs.ProductDto;
using Application.Interfaces.Product;
using AutoMapper;
using Domain.Interfaces.CategoryRepository;
using Domain.Interfaces.ProductRepository;
using Domain.Interfaces.StockRepository;
using Domain.Interfaces.SupplierRepository;
using Domain.Models.Products;

namespace Application.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStockRepository _stockRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository,ICategoryRepository categoryRepository, IStockRepository stockRepository, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _productRepository = productRepository;   
            _categoryRepository = categoryRepository;
            _stockRepository = stockRepository;
            _supplierRepository = supplierRepository;
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
                throw new Exception("Error fetching products", ex);
            }
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);

                if (product == null)
                {
                    throw new KeyNotFoundException($"Product with ID {id} not found!");
                }

                return _mapper.Map<ProductDTO>(product);

            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching product", ex);
            }

        }

        public async Task AddAsync(ProductCreateDTO productDto)
        {
            try
            {
                var productAdd = _mapper.Map<Product>(productDto);

                //Find Category
                var category = await _categoryRepository.GetByIdAsync(productDto.IdCategory);
                if (category != null)
                {
                    productAdd.Category = category;
                }
                else
                {
                    throw new Exception("Category not found!");
                }

                //Find Stock.
                var stock = await _stockRepository.GetByIdAsync(productDto.IdStock);
                if (stock != null)
                {
                    productAdd.Stock = stock;
                }
                else
                {
                    throw new Exception("Stock not found!");
                }


                //Find supplier
                var supplier = await _supplierRepository.GetByIdAsync(productDto.IdSupplier);
                if (supplier != null)
                {
                    productAdd.Supplier = supplier;
                }
                else
                {
                    throw new Exception("Supplier not found!");
                }


                await _productRepository.CreateAsync(productAdd);
            }
            catch(Exception ex)
            {       
                throw new Exception("Error adding product", ex);
            }
            
        }

        public async Task UpdateAsync(ProductUpdateDTO productDto)
        {
            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(productDto.Id);
                if (existingProduct == null)
                {
                    throw new KeyNotFoundException("Product not found!");
                }

                var productUpdate = _mapper.Map<Product>(productDto);

                await _productRepository.UpdateAsync(productUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product", ex);
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);

                if (product == null)
                {
                    throw new KeyNotFoundException("Product not found!");
                }

                await _productRepository.RemoveAsync(product);
            }
            catch(Exception ex)
            {
                throw new Exception("Error deleting product", ex);
            }

        }

    }
}
