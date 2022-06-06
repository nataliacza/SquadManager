namespace SquadManager.Dtos.Members;
public class MemberBasicsDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Mobile { get; set; }
}
