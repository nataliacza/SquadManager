using SquadManager.Dtos.Members;

namespace SquadManager.Services.Interfaces.Member;

public interface IMemberGetter
{
    Task<MemberDetailsDto> GetMemberDetails(Guid id);
    Task<MemberPropertyDto> GetMemberProperty(Guid id);
    Task<IEnumerable<MemberDogDto>> GetMemberDogList(Guid id);
    Task<IEnumerable<MemberDto>> GetMemberList();
}
