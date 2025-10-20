namespace Lab8_RodrigoApaza.DTOs;

// DTO para el ejercicio de doble consulta, representa el total de productos comprados por un cliente.
public class ClientProductCountDto
{
    public string ClientName { get; set; }
    public int TotalProducts { get; set; }
}