using Api.mappers;
using Api.repositories;
using Api.services;
using Api.services.interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IngrdientsRepository>();
builder.Services.AddAutoMapper(typeof(IngredientMapper));
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<PlateRepository>();
builder.Services.AddScoped<PlateIngredientRepository>();
builder.Services.AddScoped<PlateOrderRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<IIngredientService, IngredientsService>();
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar DbContext
builder.Services.AddDbContext<EscaleContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseSqlServer(connectionString);
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

// Habilitar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
