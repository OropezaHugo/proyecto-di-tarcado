using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class PlateIngredients: BaseEntity
{
    public int PlateId  { get; set; }
    [ForeignKey(nameof(PlateId))]
    public Plate? Plate { get; set; }
    
    public int IngredientId  { get; set; }
    [ForeignKey(nameof(IngredientId))]
    public Ingredient? Ingredient { get; set; }
}