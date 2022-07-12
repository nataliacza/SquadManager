using AutoMapper;
using SquadManager.Db;
using SquadManager.Db.Models;
using SquadManager.Dtos.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Core.Members;

public class EfMemberCreator : IMemberCreator
{
    private readonly SquadManagerContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfMemberCreator(SquadManagerContext dbContext, IMapper autoMapper)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
    }

    public async Task<MemberDto> CreateMember(SaveMemberDto createMemberDto)
    {
        var member = _autoMapper.Map<Member>(createMemberDto);

        _dbContext.Add(member);

        var properties = new MemberProperty()
        {
            MemberId = member.Id
        };

        _dbContext.Add(properties);

        member.PropertyId = properties.Id;

        await _dbContext.SaveChangesAsync();

        var dto = _autoMapper.Map<MemberDto>(member);

        return dto;
    }
}
