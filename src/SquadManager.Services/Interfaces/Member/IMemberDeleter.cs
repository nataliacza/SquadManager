using SquadManager.Dto.Members;


namespace SquadManager.Services.Interfaces.Member;

public interface IMemberDeleter
{
    Task<MemberDto> DeleteMember(Guid id);
}
