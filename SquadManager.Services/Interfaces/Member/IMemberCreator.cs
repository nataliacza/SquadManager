using SquadManager.Dtos.Members;

namespace SquadManager.Services.Interfaces.Member;

public interface IMemberCreator
{
    Task<MemberDto> CreateMember(CreateMemberDto memberDto);
}
