using SquadManager.Dto.MemberProperty;


namespace SquadManager.Dto.Members;

public class MemberWithPropertiesDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
    public MemberPropertyDto Properties { get; set; } = null!;
}
