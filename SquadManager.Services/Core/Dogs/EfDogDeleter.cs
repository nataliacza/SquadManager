using SquadManager.Dtos.Dogs;
using SquadManager.Services.Interfaces.Dog;

namespace SquadManager.Services.Core.Dogs;

public class EfDogDeleter : IDogDeleter
{
    public async Task<DogDto> DeleteDog(Guid id)
    {
        throw new NotImplementedException();
    }
}
