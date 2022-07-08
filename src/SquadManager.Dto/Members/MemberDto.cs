namespace SquadManager.Dto.Members;

public class MemberDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Mobile { get; set; } = null!;

    public Guid PropertyId { get; set; }
}
