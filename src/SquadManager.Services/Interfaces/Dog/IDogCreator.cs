using SquadManager.Dto.Dogs;


namespace SquadManager.Services.Interfaces.Dog;

public interface IDogCreator
{
    Task<DogDto> CreateDog(SaveDogDto dogDto);
}
