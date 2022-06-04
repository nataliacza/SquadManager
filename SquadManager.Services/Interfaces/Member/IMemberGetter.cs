using SquadManager.Dtos.Members;

namespace SquadManager.Services.Interfaces.Member;

public interface IMemberGetter
{
    Task<MemberDto> GetMember(Guid id);
    Task<IEnumerable<MemberDto>> GetMemberList();
}
