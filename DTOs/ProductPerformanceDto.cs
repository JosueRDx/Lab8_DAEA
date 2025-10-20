namespace Lab8_RodrigoApaza.DTOs;

// DTO para la mejora propuesta, representa el rendimiento de un producto.
public class ProductPerformanceDto
{
    public string ProductName { get; set; }
    public int TotalUnitsSold { get; set; }
    public decimal TotalRevenue { get; set; }
}