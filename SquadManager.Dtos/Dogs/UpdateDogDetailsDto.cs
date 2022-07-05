namespace SquadManager.Dtos.Dogs;

public class UpdateDogDetailsDto
{
    public string? Breeder { get; set; }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ChipNumber { get; set; }
}
