using SquadManager.Dtos.Members;

namespace SquadManager.Services.Interfaces.Member;

public interface IMemberUpdater
{
    Task<MemberDetailsDto> UpdateDetails(Guid id, SaveMemberDto updateDto);
    Task<MemberPropertyDto> UpdateProperty(Guid id, UpdateMemberPropertyDto updateDto);
    Task<MemberPropertyDto> UpdateRole(Guid id, UpdateMemberRoleDto updateDto);
}
