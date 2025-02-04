using Domain.Models.Products;

namespace Domain.Models.Suppliers
{
    public class Supplier
    {
        public Supplier(int id, string? name, string? contact, ICollection<Product>? products)
        {
            Id = id;
            Name = name;
            Contact = contact;
            Products = products;
        }
        public Supplier()
        {
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
