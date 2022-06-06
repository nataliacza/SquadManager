using AutoMapper;
using SquadManager.Database;
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

    public async Task<IEnumerable<DogDto>> GetDogList()
    {
        throw new NotImplementedException();
    }
}
