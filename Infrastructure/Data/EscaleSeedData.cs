using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public static class EscaleSeedData
{
    public static async Task SeedAsync(EscaleContext context)
    {
        if (!context.Users.Any())
        {
            var dietData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/UserData.json");
            var diets = JsonSerializer.Deserialize<List<User>>(dietData);
            if (diets != null)
            {
                context.Users.AddRange(diets);
                await context.SaveChangesAsync();
            }
        }
    }
}