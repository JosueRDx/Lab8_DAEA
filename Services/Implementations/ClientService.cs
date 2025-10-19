using Lab8_RodrigoApaza.DTOs;
using Lab8_RodrigoApaza.Infrastructure.Models;
using Lab8_RodrigoApaza.Infrastructure.UnitOfWork.Interfaces;
using Lab8_RodrigoApaza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8_RodrigoApaza.Services.Implementations;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Ejercicio 1: Obtener los Clientes que Tienen un Nombre Específico
    public async Task<IEnumerable<ClientDto>> GetByName(string name)
    {
        return await _unitOfWork.Repository<Client>()
            .AsQueryable()
            .Where(c => c.Name.StartsWith(name))
            .Select(c => new ClientDto // Mapeamos al DTO
            {
                ClientId = c.Clientid,
                Email = c.Email,
                Name = c.Name
            })
            .ToListAsync();
    }

    // Ejercicio 9: Obtener el Cliente con Mayor Número de Pedidos
    public async Task<ClientOrderStatsDto> GetWithMostOrders()
    {
        var clientGroup = await _unitOfWork.Repository<Order>()
            .AsQueryable()
            .GroupBy(o => o.Clientid)
            .Select(g => new { ClientId = g.Key, OrderCount = g.Count() })
            .OrderByDescending(x => x.OrderCount)
            .FirstOrDefaultAsync();
        
        if (clientGroup == null)
        {
            return null;
        }

        var clientInfo = await _unitOfWork.Repository<Client>().GetByIdAsync(clientGroup.ClientId);
        
        // Mapeamos al DTO en lugar de un objeto anónimo
        return new ClientOrderStatsDto 
        { 
            ClientName = clientInfo.Name, 
            OrderCount = clientGroup.OrderCount 
        };
    }

    // Ejercicio 12: Obtener Todos los Clientes que Han Comprado un Producto Específico
    public async Task<IEnumerable<string>> GetByProductPurchase(int productId)
    {
        return await _unitOfWork.Repository<Orderdetail>()
            .AsQueryable()
            .Where(od => od.Productid == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();
    }
    
    // Implementación del nuevo método de LINQ Avanzado
    public async Task<IEnumerable<ClientOrdersDto>> GetAllClientsWithOrders()
    {
        var clientOrders = await _unitOfWork.Repository<Client>()
            .AsQueryable()
            .AsNoTracking() // Mejora el rendimiento para consultas de solo lectura
            .Select(client => new ClientOrdersDto
            {
                ClientName = client.Name,
                Orders = client.Orders
                    .Select(order => new SimpleOrderDto
                    {
                        OrderId = order.Orderid,
                        OrderDate = order.Orderdate
                    }).ToList()
            })
            .ToListAsync();

        return clientOrders;
    }
}