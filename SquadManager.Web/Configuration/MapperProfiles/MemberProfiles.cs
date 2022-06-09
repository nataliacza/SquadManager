using AutoMapper;
using SquadManager.Database.Models;
using SquadManager.Dtos.Dogs;
using SquadManager.Dtos.Members;

namespace SquadManager.Web.Configuration.MapperProfiles;

public class MemberProfiles : Profile
{
    public MemberProfiles()
    {
        CreateMap<MemberDto, Member>()
            .ReverseMap();

        CreateMap<SaveMemberDto, Member>()
            .ReverseMap();

        CreateMap<MemberDetailsDto, Member>()
            .ReverseMap();

        CreateMap<MemberPropertyDto, MemberProperty>()
            .ReverseMap();

        CreateMap<MemberDogDto, Dog>()
            .ReverseMap();

        CreateMap<UpdateMemberPropertyDto, MemberProperty>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
