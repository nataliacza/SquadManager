namespace SquadManager.Dtos.Dogs;

public class DogListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid OwnerId { get; set; }
    public string OwnerFirstName { get; set; } = null!;
    public string OwnerLastName { get; set; } = null!;
}
