using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Dtos.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Core.Members;

public class EfMemberDeleter : IMemberDeleter
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfMemberDeleter(ApplicationDbContext dbContext, IMapper autoMapper)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
    }

    public async Task<MemberDto> DeleteMember(Guid id)
    {
        var member = await _dbContext.Members
            .Include(x => x.Dogs)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (member == null)
        {
            return null!;
        }

        // TODO: cover proper approach to exception handling
        if (member.Dogs!.Any())
        {
            throw new InvalidOperationException();
        }

        _dbContext.Members.Remove(member);
        await _dbContext.SaveChangesAsync();

        var dto = _autoMapper.Map<MemberDto>(member);

        return dto;
    }
}
