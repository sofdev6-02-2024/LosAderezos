using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.WithoutID;

public class UserWithoutIdDTO
{ 
    public string Name { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}
