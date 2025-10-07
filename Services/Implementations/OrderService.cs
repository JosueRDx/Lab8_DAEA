using Lab8_RodrigoApaza.DTOs;
using Lab8_RodrigoApaza.Infrastructure.Models;
using Lab8_RodrigoApaza.Infrastructure.UnitOfWork.Interfaces;
using Lab8_RodrigoApaza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8_RodrigoApaza.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Ejercicio 3: Obtener el Detalle de los Productos en una Orden
    public async Task<IEnumerable<OrderDetailDto>> GetOrderDetails(int orderId)
    {
        return await _unitOfWork.Repository<Orderdetail>()
            .AsQueryable()
            .Where(od => od.Orderid == orderId)
            .Include(od => od.Product) 
            .Select(od => new OrderDetailDto // Mapeamos al DTO
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }

    // Ejercicio 4: Obtener la Cantidad Total de Productos por Orden
    public async Task<int> GetTotalProductQuantityInOrder(int orderId)
    {
        return await _unitOfWork.Repository<Orderdetail>()
            .AsQueryable()
            .Where(od => od.Orderid == orderId)
            .SumAsync(od => od.Quantity);
    }

    // Ejercicio 6: Obtener Todos los Pedidos Realizados Después de una Fecha Específica
    public async Task<IEnumerable<OrderDto>> GetOrdersAfterDate(DateTime date)
    {
        // Nota: Este método ahora también devuelve los detalles de cada orden.
        return await _unitOfWork.Repository<Order>()
            .AsQueryable()
            .Where(o => o.Orderdate > date)
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .Select(o => new OrderDto // Mapeamos al DTO principal
            {
                OrderId = o.Orderid,
                OrderDate = o.Orderdate,
                Products = o.Orderdetails.Select(od => new OrderDetailDto // Mapeamos la lista interna
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity
                }).ToList()
            })
            .ToListAsync();
    }

    // Ejercicio 10: Obtener Todos los Pedidos y sus Detalles
    public async Task<IEnumerable<OrderDto>> GetAllWithDetails()
    {
        return await _unitOfWork.Repository<Order>()
            .AsQueryable()
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product) 
            .Select(o => new OrderDto // Mapeamos al DTO
            {
                OrderId = o.Orderid,
                OrderDate = o.Orderdate,
                Products = o.Orderdetails.Select(od => new OrderDetailDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity
                }).ToList()
            })
            .ToListAsync();
    }

    // Ejercicio 11: Obtener Todos los Productos Vendidos por un Cliente Específico
    public async Task<IEnumerable<string>> GetProductsSoldToClient(int clientId)
    {
        return await _unitOfWork.Repository<Order>()
            .AsQueryable()
            .Where(o => o.Clientid == clientId)
            .SelectMany(o => o.Orderdetails) 
            .Select(od => od.Product.Name)
            .Distinct()
            .ToListAsync();
    }
}