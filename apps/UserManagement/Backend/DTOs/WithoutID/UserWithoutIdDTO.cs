namespace Backend.DTOs.WithoutID;

public class UserWithoutIdDTO
{ 
    public string Name { get; set; } = string.Empty;
    public string Rol { get; set; } = "Operador";
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}
