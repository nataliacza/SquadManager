using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Db;
using SquadManager.Db.Models;
using SquadManager.Dtos.Dogs;
using SquadManager.Services.Interfaces.Dog;

namespace SquadManager.Services.Core.Members;

public class EfDogCreator : IDogCreator
{
    private readonly SquadManagerContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfDogCreator(SquadManagerContext dbContext, IMapper autoMapper)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
    }

    public async Task<DogDto> CreateDog(SaveDogDto createDogDto)
    {
        var member = await _dbContext.Members
            .FirstOrDefaultAsync(x => x.Id == createDogDto.OwnerId);

        //TODO: handle exception
        if (member == null)
        {
            return null!;
        }

        var dog = _autoMapper.Map<Dog>(createDogDto);

        _dbContext.Add(dog);
        await _dbContext.SaveChangesAsync();

        var dto = _autoMapper.Map<DogDto>(dog);

        return dto;
    }
}
