using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Dto.Dogs;
using SquadManager.Services.Exceptions;
using SquadManager.Services.Interfaces.Dog;


namespace SquadManager.Services.Core.Dogs;

public class EfDogGetter : IDogGetter
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfDogGetter(ApplicationDbContext dbContext, IMapper autoMapper)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
    }

    public async Task<DogDto> GetDog(Guid id)
    {
        var dog = await _dbContext.Dogs
            .Include(x => x.Owner)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (dog == null)
        {
            throw new NotFoundException();
        }

        var dto = _autoMapper.Map<DogDto>(dog);

        return dto;
    }

    public async Task<IEnumerable<DogListDto>> GetDogList()
    {
        var dog = await _dbContext.Dogs
            .Include(x => x.Owner)
            .ToArrayAsync();

        var dto = _autoMapper.Map<IEnumerable<DogListDto>>(dog);

        return dto;
    }
}
