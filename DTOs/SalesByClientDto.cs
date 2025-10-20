namespace Lab8_RodrigoApaza.DTOs;

// DTO para el ejercicio de agrupación, representa el total de ventas por cliente.
public class SalesByClientDto
{
    public string ClientName { get; set; }
    public decimal TotalSales { get; set; }
}