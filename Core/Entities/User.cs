namespace Core.Entities;

public class User: BaseEntity
{
    public required string Name { get; set; }
    public DateOnly BirthDate { get; set; }

    public List<Order> UserPlates { get; set; } = new List<Order>();
}