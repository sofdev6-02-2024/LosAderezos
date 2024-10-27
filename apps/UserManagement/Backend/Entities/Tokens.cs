namespace Backend.Entities;

public class Tokens
{
    public Guid TokenId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    
    //Foreign Key
    public Guid UserId { get; set; }
}