namespace Backend.DTOs.WithoutID;

public class UpdateUserDTO
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}
