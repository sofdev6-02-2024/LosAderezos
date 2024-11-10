namespace Backend.DTOs.WithoutID;

public class TokenWithoutIdDTO
{
    public string Token { get; set; } = string.Empty;

    public DateTime Time { get;set; }
    
    //Foreign Key
    public Guid UserId { get; set; }
}
