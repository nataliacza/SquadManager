using System.ComponentModel.DataAnnotations;

namespace SquadManager.Dtos.Dogs;

public class CreateDogDto
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = null!;

    [MaxLength(50)]
    public string? Breeder { get; set; }

    [MaxLength(50)]
    public string? Gender { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime DateOfBirth { get; set; }

    [MaxLength(50)]
    public string? ChipNumber { get; set; }

    [Required]
    public Guid OwnerId { get; set; }
}
