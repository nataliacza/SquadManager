using SquadManager.Dtos.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Core.Members;

public class EfMemberUpdater : IMemberUpdater
{
    public async Task<SaveMemberDto> UpdateMemberBasicDetails(Guid id)
    {
        throw new NotImplementedException();
    }
}
