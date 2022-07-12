using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Dto.Dogs;
using SquadManager.Services.Exceptions;
using SquadManager.Services.Interfaces.Dog;


namespace SquadManager.Services.Core.Dogs;

public class EfDogDeleter : IDogDeleter
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public EfDogDeleter(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<DogDto> DeleteDog(Guid id)
    {
        var dog = await _dbContext.Dogs
            .FirstOrDefaultAsync(x => x.Id == id);

        if (dog == null)
        {
            throw new NotFoundException();
        }

        _dbContext.Remove(dog);
        await _dbContext.SaveChangesAsync();

        var dto = _mapper.Map<DogDto>(dog);

        return dto;
    }
}
