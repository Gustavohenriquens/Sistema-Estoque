using Application.DTOs.CategoryDto;
using Application.DTOs.ProductDto;
using Application.DTOs.StockDto;
using Application.DTOs.SupplierDto;
using AutoMapper;
using Domain.Models.Categories;
using Domain.Models.Products;
using Domain.Models.Stocks;
using Domain.Models.Suppliers;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();

            CreateMap<Stock, StockDTO>().ReverseMap();
            CreateMap<Stock, StockCreateDTO>().ReverseMap();
            CreateMap<Stock, StockUpdateDTO>().ReverseMap();

            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<Supplier, SupplierCreateDTO>().ReverseMap();
            CreateMap<Supplier, SupplierUpdateDTO>().ReverseMap();
        }
    }
}
