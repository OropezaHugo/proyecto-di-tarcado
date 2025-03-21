using Api.repositories;
using Api.services;
using Api.services.interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IngrdientsRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<PlateRepository>();
builder.Services.AddScoped<PlateIngredientRepository>();
builder.Services.AddScoped<PlateOrderRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<IIngredientService, IngredientsService>();
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddDbContext<EscaleContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseSqlServer(connectionString);
});
builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();