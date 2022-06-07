using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Dtos.Dogs;
using SquadManager.Dtos.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Core.Members;

public class EfMemberGetter : IMemberGetter
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfMemberGetter(ApplicationDbContext dbContext, IMapper autoMapper)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
    }

    public async Task<MemberBasicsDto> GetMember(Guid id)
    {
        var member = await _dbContext.Members
            .FirstOrDefaultAsync(x => x.Id == id);

        if (member == null)
        {
            return null!;
        }

        var dto = _autoMapper.Map<MemberBasicsDto>(member);

        return dto;
    }

    public async Task<MemberPropertyDto> GetMemberProperty(Guid id)
    {
        var member = await _dbContext.MemberProperties
            .FirstOrDefaultAsync(x => x.MemberId == id);

        if (member == null)
        {
            return null!;
        }

        var dto = _autoMapper.Map<MemberPropertyDto>(member);

        return dto;
    }

    public async Task<IEnumerable<MemberDogDto>> GetMemberDogList(Guid id)
    {
        var member = await _dbContext.Members
            .FirstOrDefaultAsync(x => x.Id == id);

        if (member == null)
        {
            return null!;
        }

        var dogs = await _dbContext.Dogs
            .Where(x => x.OwnerId == member.Id)
            .ToArrayAsync();
        
        var dto = _autoMapper.Map<IEnumerable<MemberDogDto>>(dogs);

        return dto;
    }

    public async Task<IEnumerable<MemberDto>> GetMemberList()
    {
        var members = await _dbContext.Members
            .ToArrayAsync();

        var dto = _autoMapper.Map<IEnumerable<MemberDto>>(members);

        return dto;
    }
}
