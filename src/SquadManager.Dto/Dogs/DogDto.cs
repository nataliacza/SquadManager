using SquadManager.Database.Enums;


namespace SquadManager.Dto.Dogs;

public class DogDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Breeder { get; set; }
    public DogGender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ChipNumber { get; set; }

    public Guid OwnerId { get; set; }
    public string OwnerFirstName { get; set; } = null!;
    public string OwnerLastName { get; set; } = null!;
}
