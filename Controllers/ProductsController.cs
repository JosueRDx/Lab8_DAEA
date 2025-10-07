using Lab8_RodrigoApaza.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_RodrigoApaza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/products/priced-greater-than?price=20
    // Corresponde al Ejercicio 2
    [HttpGet("priced-greater-than")]
    public async Task<IActionResult> GetPricedGreaterThan([FromQuery] decimal price = 20)
    {
        var products = await _productService.GetPricedGreaterThan(price);
        return Ok(products);
    }

    // GET: api/products/most-expensive
    // Corresponde al Ejercicio 5
    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensive()
    {
        var product = await _productService.GetMostExpensive();
        if (product == null)
        {
            return NotFound("No se encontraron productos.");
        }
        return Ok(product);
    }
    
    // GET: api/products/average-price
    // Corresponde al Ejercicio 7
    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var average = await _productService.GetAveragePrice();
        return Ok(new { AveragePrice = average });
    }

    // GET: api/products/no-description
    // Corresponde al Ejercicio 8
    [HttpGet("no-description")]
    public async Task<IActionResult> GetWithNoDescription()
    {
        var products = await _productService.GetWithNoDescription();
        return Ok(products);
    }
}