using SquadManager.Database.Enums;
using SquadManager.Dto.Validation;
using System.ComponentModel.DataAnnotations;


namespace SquadManager.Dto.Dogs;

public class UpdateDogDetailsDto
{
    [MaxLength(30)]
    public string? Breeder { get; set; }

    [EnumDataType(typeof(DogGender))]
    [Range(0, 2)]
    public DogGender Gender { get; set; }

    [DataType(DataType.Date)]
    [NotFutureDate]
    public DateTime? DateOfBirth { get; set; }

    [MaxLength(50)]
    public string? ChipNumber { get; set; }
}
