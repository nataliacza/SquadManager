using SquadManager.Dto.Dogs;


namespace SquadManager.Services.Interfaces.Dog;

public interface IDogDeleter
{
    Task<DogDto> DeleteDog(Guid id);
}
