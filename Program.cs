using Lab8_RodrigoApaza.Infrastructure.Data;
using Lab8_RodrigoApaza.Infrastructure.Repositories.Implementations;
using Lab8_RodrigoApaza.Infrastructure.Repositories.Interfaces;
using Lab8_RodrigoApaza.Infrastructure.UnitOfWork.Implementations;
using Lab8_RodrigoApaza.Infrastructure.UnitOfWork.Interfaces;
using Lab8_RodrigoApaza.Services.Implementations; 
using Lab8_RodrigoApaza.Services.Interfaces;    
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext
builder.Services.AddDbContext<LinqDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección del repositorio genérico y UnitOfWork
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();


// Swagger y controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();