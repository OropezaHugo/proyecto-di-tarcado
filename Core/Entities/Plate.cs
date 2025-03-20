namespace Core.Entities;

public class Plate: BaseEntity
{
    public required string Name { get; set; }
    public  required double Price { get; set; }
    public List<UserPlates> UserPlates { get; set; } = new List<UserPlates>();
    public List<PlateIngredients> PlateIngredients { get; set; } = new List<PlateIngredients>();
}