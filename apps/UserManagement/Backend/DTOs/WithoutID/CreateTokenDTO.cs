namespace Backend.DTOs.WithoutID;

public class CreateTokenDTO
{
    public required string Email { get; set; }
    public required string Token { get; set; }
}
