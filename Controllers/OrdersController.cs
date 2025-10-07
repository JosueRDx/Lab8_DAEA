using Lab8_RodrigoApaza.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_RodrigoApaza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    { 
        _orderService = orderService;
    } 

    // GET: api/orders/1/details
    // Corresponde al Ejercicio 3
    [HttpGet("{orderId}/details")]
    public async Task<IActionResult> GetOrderDetails(int orderId = 1)
    {
        var details = await _orderService.GetOrderDetails(orderId);
        return Ok(details);
    }

    // GET: api/orders/1/total-quantity
    // Corresponde al Ejercicio 4
    [HttpGet("{orderId}/total-quantity")]
    public async Task<IActionResult> GetTotalProductQuantityInOrder(int orderId = 1)
    {
        var total = await _orderService.GetTotalProductQuantityInOrder(orderId);
        return Ok(new { TotalQuantity = total });
    }

    // GET: api/orders/after-date?date=2025-05-01
    // Corresponde al Ejercicio 6
    [HttpGet("after-date")]
    public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date = default)
    {
        // Si no se provee fecha, se usa la del ejemplo del laboratorio.
        var queryDate = date == default ? new DateTime(2025, 5, 1) : date;
        var orders = await _orderService.GetOrdersAfterDate(queryDate);
        return Ok(orders);
    }

    // GET: api/orders/with-details
    // Corresponde al Ejercicio 10
    [HttpGet("with-details")]
    public async Task<IActionResult> GetAllWithDetails()
    {
        var orders = await _orderService.GetAllWithDetails();
        return Ok(orders);
    }
    
    // GET: api/orders/products-sold-to/1
    // Corresponde al Ejercicio 11
    [HttpGet("products-sold-to/{clientId}")]
    public async Task<IActionResult> GetProductsSoldToClient(int clientId = 1)
    {
        var productNames = await _orderService.GetProductsSoldToClient(clientId);
        return Ok(productNames);
    }
}