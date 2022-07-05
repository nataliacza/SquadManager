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

        CreateMap<SaveDogDto, Dog>()
            .ReverseMap();

        CreateMap<DogListDto, Dog>()
            .ReverseMap();
    }
}
