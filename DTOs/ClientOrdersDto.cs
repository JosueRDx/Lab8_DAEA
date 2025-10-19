namespace Lab8_RodrigoApaza.DTOs;

// DTO para el ejercicio de AsNoTracking, representa un cliente y sus órdenes.
public class ClientOrdersDto
{
    public string ClientName { get; set; }
    public List<SimpleOrderDto> Orders { get; set; } = new();
}