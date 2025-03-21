using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class EscaleContext(DbContextOptions options): DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Plate> Plates { get; set; }
    public DbSet<PlateOrder> PlateOrders { get; set; }
    public DbSet<PlateIngredients> PlateIngredients { get; set; }
    public DbSet<Order> Orders { get; set; }
}
