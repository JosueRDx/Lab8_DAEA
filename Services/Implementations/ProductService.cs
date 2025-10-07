using Lab8_RodrigoApaza.DTOs; 
using Lab8_RodrigoApaza.Infrastructure.Models;
using Lab8_RodrigoApaza.Infrastructure.UnitOfWork.Interfaces;
using Lab8_RodrigoApaza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8_RodrigoApaza.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Ejercicio 2: Obtener los Productos con Precio Mayor a un Valor Específico
    public async Task<IEnumerable<ProductDto>> GetPricedGreaterThan(decimal price)
    {
        return await _unitOfWork.Repository<Product>()
            .AsQueryable()
            .Where(p => p.Price > price)
            .Select(p => new ProductDto 
            {
                ProductId = p.Productid,
                Name = p.Name,
                Price = p.Price
            })
            .ToListAsync();
    }

    // Ejercicio 5: Obtener el Producto Más Caro 
    public async Task<ProductDto> GetMostExpensive()
    {
        return await _unitOfWork.Repository<Product>()
            .AsQueryable()
            .OrderByDescending(p => p.Price)
            .Select(p => new ProductDto 
            {
                ProductId = p.Productid,
                Name = p.Name,
                Price = p.Price
            })
            .FirstOrDefaultAsync();
    }

    // Ejercicio 7: Obtener el Promedio de Precio de los Productos 
    public async Task<decimal> GetAveragePrice()
    {
        return await _unitOfWork.Repository<Product>()
            .AsQueryable()
            .AverageAsync(p => p.Price);
    }

    // Ejercicio 8: Obtener Todos los Productos que No Tienen Descripción 
    public async Task<IEnumerable<ProductDto>> GetWithNoDescription()
    {
        return await _unitOfWork.Repository<Product>()
            .AsQueryable()
            .Where(p => string.IsNullOrEmpty(p.Description))
            .Select(p => new ProductDto 
            {
                ProductId = p.Productid,
                Name = p.Name,
                Price = p.Price
            })
            .ToListAsync();
    }
}