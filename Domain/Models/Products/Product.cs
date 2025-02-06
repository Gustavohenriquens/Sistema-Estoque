using Domain.Models.Categories;
using Domain.Models.Movementation;
using Domain.Models.Stocks;
using Domain.Models.Suppliers;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models.Products
{
    public class Product
    {
        public Product(int id, string? name, DateTime validation, string? description, int idCategory, Category category, int idStock, Stock stock, int idSupplier, Supplier supplier, decimal priceCost, decimal priceSale, int amount)
        {
            Id = id;
            Name = name;
            Validation = validation;
            Description = description;
            IdCategory = idCategory;
            Category = category;
            IdStock = idStock;
            Stock = stock;
            IdSupplier = idSupplier;
            Supplier = supplier;
            PriceCost = priceCost;
            PriceSale = priceSale;
            Amount = amount;
        }

        public Product()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public DateTime Validation { get; set; }
        public string? Description { get; set; }

        [Required]
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public int IdStock { get; set; }
        public Stock Stock { get; set; }
        public int IdSupplier { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceCost { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]        
        public decimal PriceSale { get; set; }
        public int Amount { get; set; }

        public ICollection<Movement> Movements  { get; set; }
    }
}
