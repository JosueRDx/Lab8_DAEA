using Lab8_RodrigoApaza.DTOs;
using Lab8_RodrigoApaza.Infrastructure.Models;

namespace Lab8_RodrigoApaza.Services.Interfaces;

public interface IOrderService
{
    // Ejercicio 3: Obtener el Detalle de los Productos en una Orden
    Task<IEnumerable<OrderDetailDto>> GetOrderDetails(int orderId);

    // Ejercicio 4: Obtener la Cantidad Total de Productos por Orden
    Task<int> GetTotalProductQuantityInOrder(int orderId);

    // Ejercicio 6: Obtener Todos los Pedidos Realizados Después de una Fecha Específica
    Task<IEnumerable<OrderDto>> GetOrdersAfterDate(DateTime date);

    // Ejercicio 10: Obtener Todos los Pedidos y sus Detalles (Nombre del Producto y Cantidad)
    Task<IEnumerable<OrderDto>> GetAllWithDetails();
    
    // Ejercicio 11: Obtener Todos los Productos Vendidos por un Cliente Específico
    Task<IEnumerable<string>> GetProductsSoldToClient(int clientId);
}