using SquadManager.Dtos.Dogs;

namespace SquadManager.Services.Interfaces.Dog;

public interface IDogCreator
{
    Task<DogDto> CreateDog(CreateDogDto dogDto);
}
