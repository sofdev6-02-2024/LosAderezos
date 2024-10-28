namespace Backend.Entities;

public class Tokens
{
    public string Token { get; set; } = string.Empty;
    
    //Foreign Key
    public Guid UserId { get; set; }
}