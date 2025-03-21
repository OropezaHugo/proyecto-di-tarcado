namespace Core.Entities;

public class Ingredient: BaseEntity
{
    public required string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public List<PlateIngredients> PlateIngredients { get; set; } = new List<PlateIngredients>();
}
