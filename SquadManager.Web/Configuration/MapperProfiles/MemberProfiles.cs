using AutoMapper;
using SquadManager.Database.Models;
using SquadManager.Dtos.Members;

namespace SquadManager.Web.Configuration.MapperProfiles;

public class MemberProfiles : Profile
{
    public MemberProfiles()
    {
        CreateMap<MemberDto, Member>()
            .ReverseMap();

        CreateMap<CreateMemberDto, Member>()
            .ReverseMap();

        CreateMap<Member, MemberDto>()
            .ForMember(
                d => d.Dogs,
                opt => opt.MapFrom(
                    s => s.Dogs)
                );
    }
}
