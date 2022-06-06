namespace SquadManager.Dtos.Members;

public class MemberDogDto
{
    public Guid MemberId { get; set; }
    public Guid DogId { get; set; }
    public string DogName { get; set; } = null!;
}
