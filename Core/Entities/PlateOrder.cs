using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class PlateOrder: BaseEntity
{

    public int PlateId  { get; set; }
    [ForeignKey(nameof(PlateId))]
    public int Quantity { get; set; }
    public Plate? Plate { get; set; }
    
}
