using SquadManager.Dtos.Dogs;

namespace SquadManager.Services.Interfaces.Dog;

public interface IDogGetter
{
    Task<DogDto> GetDog(Guid id);
    Task<IEnumerable<DogDto>> GetDogList();
}
