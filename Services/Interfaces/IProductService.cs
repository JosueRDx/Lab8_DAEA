using Lab8_RodrigoApaza.DTOs; 

namespace Lab8_RodrigoApaza.Services.Interfaces;

public interface IProductService
{
    // Ejercicio 2: Obtener los Productos con Precio Mayor a un Valor Específico
    Task<IEnumerable<ProductDto>> GetPricedGreaterThan(decimal price);

    // Ejercicio 5: Obtener el Producto Más Caro
    Task<ProductDto> GetMostExpensive();

    // Ejercicio 7: Obtener el Promedio de Precio de los Productos
    Task<decimal> GetAveragePrice();

    // Ejercicio 8: Obtener Todos los Productos que No Tienen Descripción
    Task<IEnumerable<ProductDto>> GetWithNoDescription();
}