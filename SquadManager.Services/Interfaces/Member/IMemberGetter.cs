using SquadManager.Dtos.Members;

namespace SquadManager.Services.Interfaces.Member;

public interface IMemberGetter
{
    Task<MemberBasicsDto> GetMember(Guid id);
    Task<MemberPropertyDto> GetMemberProperty(Guid id);
    Task<IEnumerable<MemberDto>> GetMemberList();
}
