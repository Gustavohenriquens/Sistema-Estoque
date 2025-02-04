using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Stocks
{
    public class Stock
    {
        public Stock(int id, string name, int maximumCapacity, ICollection<Product>? products)
        {
            Id = id;
            Name = name;
            MaximumCapacity = maximumCapacity;
            Products = products;
        }

        public Stock()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int MaximumCapacity { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
