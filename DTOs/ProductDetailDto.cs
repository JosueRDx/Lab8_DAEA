namespace Lab8_RodrigoApaza.DTOs;

// DTO para el ejercicio de Include, representa el detalle de un producto en una orden.
public class ProductDetailDto
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}