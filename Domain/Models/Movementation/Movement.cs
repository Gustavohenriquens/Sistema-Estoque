using Domain.Models.Products;

namespace Domain.Models.Movementation
{
    public abstract class Movement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Responsible { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // "Entry" or "Exit"
    }
}
