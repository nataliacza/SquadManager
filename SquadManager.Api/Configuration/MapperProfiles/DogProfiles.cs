using AutoMapper;
using SquadManager.Db.Models;
using SquadManager.Dtos.Dogs;

namespace SquadManager.Api.Configuration.MapperProfiles;

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

        CreateMap<UpdateDogDetailsDto, Dog>()
            .ReverseMap();
    }
}
