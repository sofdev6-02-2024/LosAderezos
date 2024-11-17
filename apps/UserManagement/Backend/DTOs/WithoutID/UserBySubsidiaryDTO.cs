namespace Backend.DTOs.WithoutID;

public class UserBySubsidiaryDTO
{
    public Guid SubsidiaryId { get; set; }
    public string Email { get; set; } = string.Empty;
}