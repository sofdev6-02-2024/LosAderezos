namespace Backend.DTOs.WithID;

public class ValidateTokenDTO
{
    
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
}
