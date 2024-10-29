namespace Backend.DTOs.WithID;

public class UserDTO
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}