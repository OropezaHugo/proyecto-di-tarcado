using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class UserPlates: BaseEntity
{
    public int UserId  { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    public int PlateId  { get; set; }
    [ForeignKey(nameof(PlateId))]
    public Plate? Plate { get; set; }
    
}