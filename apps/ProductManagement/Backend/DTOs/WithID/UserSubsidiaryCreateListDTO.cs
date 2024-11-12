namespace Backend.DTOs.WithID;

public class UserSubsidiaryCreateListDTO
{
    public List<Guid> UserIds { get; set; } = new List<Guid>();
    public Guid SubsidiaryId { get; set; }
}