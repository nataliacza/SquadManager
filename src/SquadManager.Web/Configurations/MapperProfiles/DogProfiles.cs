using AutoMapper;
using SquadManager.Database.Models;
using SquadManager.Dto.Dogs;


namespace SquadManager.Web.Configurations.MapperProfiles;

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
