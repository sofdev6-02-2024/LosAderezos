namespace Backend.DTOs.WithoutID;

public class UserFullInfoDTO
{
    //User
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    
    //Token
    public string Token { get; set; } = string.Empty;
    public DateTime Time { get;set; }
}
