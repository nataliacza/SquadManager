using AutoMapper;
using SquadManager.Database;
using SquadManager.Dtos.Dogs;
using SquadManager.Services.Interfaces.Dog;

namespace SquadManager.Services.Core.Dogs;

public class EfDogUpdater : IDogUpdater
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public EfDogUpdater(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<DogDto> UpdateDog(Guid id, SaveDogDto updateDto)
    {
        throw new NotImplementedException();
    }
}
