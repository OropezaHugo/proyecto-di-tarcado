using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EscaleContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseSqlServer(connectionString);
});
builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthorization();

app.MapControllers();
try
{
    using var scoped = app.Services.CreateScope();
    var services = scoped.ServiceProvider;
    var context = services.GetRequiredService<EscaleContext>();
    await context.Database.MigrateAsync();
    await EscaleSeedData.SeedAsync(context);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
app.Run();