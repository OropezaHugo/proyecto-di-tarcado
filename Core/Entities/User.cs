namespace Core.Entities;

public class User: BaseEntity
{
    public required string Name { get; set; }
    public DateOnly BirthDate { get; set; }

    public List<UserPlates> UserPlates { get; set; } = new List<UserPlates>();
}