using Lab8_RodrigoApaza.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_RodrigoApaza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    // GET: api/clients/by-name?name=Juan
    // Corresponde al Ejercicio 1
    [HttpGet("by-name")]
    public async Task<IActionResult> GetByName([FromQuery] string name = "Juan")
    {
        var clients = await _clientService.GetByName(name);
        return Ok(clients);
    }

    // GET: api/clients/most-orders
    // Corresponde al Ejercicio 9
    [HttpGet("most-orders")]
    public async Task<IActionResult> GetWithMostOrders()
    {
        var client = await _clientService.GetWithMostOrders();
        if (client == null)
        {
            return NotFound("No se encontraron clientes con órdenes.");
        }
        return Ok(client);
    }

    // GET: api/clients/by-product-purchase/2
    // Corresponde al Ejercicio 12
    [HttpGet("by-product-purchase/{productId}")]
    public async Task<IActionResult> GetByProductPurchase(int productId = 2)
    {
        var clientNames = await _clientService.GetByProductPurchase(productId);
        return Ok(clientNames);
    }
    
    // GET: api/clients/with-orders
    [HttpGet("with-orders")]
    public async Task<IActionResult> GetAllClientsWithOrders()
    {
        var result = await _clientService.GetAllClientsWithOrders();
        return Ok(result);
    }
    
    // GET: api/clients/with-product-counts
    [HttpGet("with-product-counts")]
    public async Task<IActionResult> GetClientProductCounts()
    {
        var result = await _clientService.GetClientProductCounts();
        return Ok(result);
    }
}