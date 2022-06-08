using SquadManager.Dtos.Members;

namespace SquadManager.Services.Interfaces.Member;

public interface IMemberUpdater
{
    Task<SaveMemberDto> UpdateDetails(Guid id, SaveMemberDto memberDto);
    Task<UpdateMemberPropertyDto> UpdateProperty(Guid id, UpdateMemberPropertyDto propertyDto);
}
