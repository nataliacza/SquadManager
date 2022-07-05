using SquadManager.Dtos.Dogs;

namespace SquadManager.Services.Interfaces.Dog;

public interface IDogUpdater
{
    Task<DogDto> UpdateDog(Guid id, SaveDogDto updateDto);
}
