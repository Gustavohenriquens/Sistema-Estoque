using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ProductDto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Validation { get; set; }
        public string? Description { get; set; }
        public int IdCategory { get; set; }
        public int IdStock { get; set; }
        public int IdSupplier { get; set; }
        public decimal PriceCost { get; set; }
        public decimal PriceSale { get; set; }
        public int Amount { get; set; }
    }
}
