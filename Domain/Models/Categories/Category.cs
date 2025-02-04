using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Categories
{
    public class Category
    {
        public Category(int id, string name, string? description, ICollection<Product>? products)
        {
            Id = id;
            Name = name;
            Description = description;
            Products = products;
        }

        public Category()
        {         
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
