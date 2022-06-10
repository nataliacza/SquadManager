using SquadManager.Dtos.Members;

namespace SquadManager.Services.Interfaces.Member;

public interface IMemberDeleter
{
    Task<MemberDto> DeleteMember(Guid id);
}
