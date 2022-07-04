using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Database.Models;
using SquadManager.Dtos.Dogs;
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
        throw new NotImplementedException();
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
