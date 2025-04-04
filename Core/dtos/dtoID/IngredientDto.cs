namespace Core.dtos.dtoID;

public class IngredientDto
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public double Price { get; set; }
  public int Stock { get; set; }
}
