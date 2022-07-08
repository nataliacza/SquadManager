using SquadManager.Dto.Members;


namespace SquadManager.Services.Interfaces.Member;

public interface IMemberCreator
{
    Task<MemberDto> CreateMember(SaveMemberDto memberDto);
}
