
namespace Application.DTOs.StockDto
{
    public class StockUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MaximumCapacity { get; set; }
    }
}
