namespace Backend.Entities;

public class SubsidiaryUsers
{
    //Foreign Key
    public Guid UserId { get; set; }
    public Guid SubsidiaryId { get; set; }
}
