using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Order: BaseEntity
{
  public int UserId  { get; set; }
  [ForeignKey(nameof(UserId))]
  public User? User { get; set; }
  public int PlateOrderId  { get; set; }
  [ForeignKey(nameof(PlateOrderId))]
  public PlateOrder? PlateOrder { get; set; }
}
  