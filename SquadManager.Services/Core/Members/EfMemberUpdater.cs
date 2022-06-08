using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Dtos.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Core.Members;

public class EfMemberUpdater : IMemberUpdater
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfMemberUpdater(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _autoMapper = mapper;
    }

    public async Task<SaveMemberDto> UpdateMemberBasicDetails(Guid id, SaveMemberDto memberDto)
    {
        var member = await _dbContext.Members
            .FirstOrDefaultAsync(x => x.Id == id);

        if (member == null)
        {
            return null!;
        }

        member.FirstName = memberDto.FirstName;
        member.LastName = memberDto.LastName;
        member.Email = memberDto.Email;
        member.Mobile = memberDto.Mobile;

        _dbContext.Members.Update(member);
        await _dbContext.SaveChangesAsync();

        var dto = _autoMapper.Map<SaveMemberDto>(member);

        return dto;
    }
}
