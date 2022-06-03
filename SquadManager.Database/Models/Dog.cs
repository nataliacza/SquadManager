namespace SquadManager.Database.Models;

public class Dog
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Breeder { get; set; }
    public string? Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ChipNumber { get; set; }

    public Guid OwnerId { get; set; }
    public virtual Member Owner { get; set; } = null!;

    public virtual ICollection<Exam>? Exams { get; set; }
}
