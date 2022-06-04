using SquadManager.Database.Models;

namespace SquadManager.Dtos.Members;

public class MemberDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Mobile { get; set; }

    public Guid PropertyId { get; set; }

    public IEnumerable<Dog>? Dogs { get; set; }
}
