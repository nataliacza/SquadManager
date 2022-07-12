using SquadManager.Db.Enums;

namespace SquadManager.Db.Models;

public class Dog
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Breeder { get; set; }
    public DogGender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ChipNumber { get; set; }

    public Guid OwnerId { get; set; }
    public virtual Member Owner { get; set; } = null!;

    public virtual ICollection<Exam>? Exams { get; set; }
}
