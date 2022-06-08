using SquadManager.Dtos.Members;

namespace SquadManager.Services.Interfaces.Member;

public interface IMemberUpdater
{
    Task<SaveMemberDto> UpdateMemberBasicDetails(Guid id, SaveMemberDto memberDto);
    //Task<UpdateMemberPropertyDto> UpdateMemberProperty(Guid id);
}
