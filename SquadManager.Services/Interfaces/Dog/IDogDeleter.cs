using SquadManager.Dtos.Dogs;

namespace SquadManager.Services.Interfaces.Dog;

public interface IDogDeleter
{
    Task<DogDto> DeleteDog(Guid id);
}
