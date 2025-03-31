using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Core.Entities;

public class User
{
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public DateOnly BirthDate { get; set; }

}
