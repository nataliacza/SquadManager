namespace SquadManager.Dtos.Dogs;

public class SaveDogDto
{
    public string Name { get; set; } = null!;
    public Guid OwnerId { get; set; }
}
