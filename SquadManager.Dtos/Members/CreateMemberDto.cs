using System.ComponentModel.DataAnnotations;

namespace SquadManager.Dtos.Members;

public class CreateMemberDto
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(30)]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; } = null!;
    
    [Required]
    [Phone]
    [MinLength(9)][MaxLength(10)]
    public string Mobile { get; set; } = null!;
}
