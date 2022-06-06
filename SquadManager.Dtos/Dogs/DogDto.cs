using System.ComponentModel.DataAnnotations;

namespace SquadManager.Dtos.Dogs;

public class DogDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Breeder { get; set; }
    public string? Gender { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime DateOfBirth { get; set; }
    public string? ChipNumber { get; set; }

    public Guid OwnerId { get; set; }
}
