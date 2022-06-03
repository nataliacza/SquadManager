namespace SquadManager.Database.Models;

public class Member
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Mobile { get; set; }

    public Guid PropertyId { get; set; }
    public virtual MemberProperty Properties { get; set; } = null!;

    public virtual ICollection<Dog>? Dogs { get; set; }
    public virtual ICollection<Exam>? Exams { get; set; }
}
