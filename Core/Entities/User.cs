namespace Core.Entities;

public class User: BaseEntity
{
    public required string Name { get; set; }
    public DateOnly BirthDate { get; set; }

    public List<Order> Orders { get; set; } = new List<Order>();
}
