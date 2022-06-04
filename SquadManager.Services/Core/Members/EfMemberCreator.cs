using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Database.Models;
using SquadManager.Dtos.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Core.Members;

public class EfMemberCreator : IMemberCreator
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfMemberCreator(ApplicationDbContext dbContext, IMapper autoMapper)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
    }

    public async Task<MemberDto> CreateMember(CreateMemberDto createMemberDto)
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
