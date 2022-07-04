using AutoMapper;
using SquadManager.Database.Models;
using SquadManager.Dtos.Dogs;

namespace SquadManager.Web.Configuration.MapperProfiles;

public class DogProfiles : Profile
{
    public DogProfiles()
    {
        CreateMap<DogDto, Dog>()
            .ReverseMap();

        CreateMap<CreateDogDto, Dog>()
            .ReverseMap();

        CreateMap<DogListDto, Dog>()
            .ReverseMap();
    }
}
