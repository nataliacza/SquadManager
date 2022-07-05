using SquadManager.Db.Enums;

namespace SquadManager.Dtos.Dogs;

public class UpdateDogDetailsDto
{
    public string? Breeder { get; set; }
    public DogGender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ChipNumber { get; set; }
}
