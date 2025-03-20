namespace Core.Entities;

public class Plate: BaseEntity
{
    public required string Name { get; set; }
    public  required double Price { get; set; }
    public List<PlateOrder> UserPlates { get; set; } = new List<PlateOrder>();
    public List<PlateIngredients> PlateIngredients { get; set; } = new List<PlateIngredients>();
}