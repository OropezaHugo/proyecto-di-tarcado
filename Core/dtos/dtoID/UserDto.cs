namespace Core.dtos.dtoID;

public class UserDto
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
  public DateOnly BirthDate { get; set; }
}
