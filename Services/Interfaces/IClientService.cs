using Lab8_RodrigoApaza.DTOs;

namespace Lab8_RodrigoApaza.Services.Interfaces;

public interface IClientService
{
    // Ejercicio 1: Obtener los Clientes que Tienen un Nombre Específico
    Task<IEnumerable<ClientDto>> GetByName(string name);

    // Ejercicio 9: Obtener el Cliente con Mayor Número de Pedidos
    Task<ClientOrderStatsDto> GetWithMostOrders();

    // Ejercicio 12: Obtener Todos los Clientes que Han Comprado un Producto Específico
    Task<IEnumerable<string>> GetByProductPurchase(int productId);
    
    // Nuevo método para LINQ Avanzado
    Task<IEnumerable<ClientOrdersDto>> GetAllClientsWithOrders();
    
    // Nuevo método para el ejercicio de doble consulta
    Task<IEnumerable<ClientProductCountDto>> GetClientProductCounts();
    
    // Nuevo método para el ejercicio de agrupación
    Task<IEnumerable<SalesByClientDto>> GetSalesByClient();
}