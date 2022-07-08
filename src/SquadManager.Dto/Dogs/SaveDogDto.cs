using System.ComponentModel.DataAnnotations;


namespace SquadManager.Dto.Dogs;

public class SaveDogDto
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = null!;

    [Required]
    public Guid OwnerId { get; set; }
}
