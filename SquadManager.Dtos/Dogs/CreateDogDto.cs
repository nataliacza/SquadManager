namespace SquadManager.Dtos.Dogs;

public class CreateDogDto
{
    public string Name { get; set; } = null!;
    public Guid OwnerId { get; set; }
}
