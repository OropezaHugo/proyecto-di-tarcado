using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Order: BaseEntity
{
  public Guid UserId  { get; set; }
  public int PlateOrderId  { get; set; }
  [ForeignKey(nameof(PlateOrderId))]
  public PlateOrder? PlateOrder { get; set; }
}
  