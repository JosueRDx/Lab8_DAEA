namespace Lab8_RodrigoApaza.DTOs;

// DTO para representar una orden completa.
public class OrderDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ProductDetailDto> Products { get; set; } = new();
}