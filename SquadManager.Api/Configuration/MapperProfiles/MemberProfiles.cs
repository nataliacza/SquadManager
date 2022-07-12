using AutoMapper;
using SquadManager.Db.Models;
using SquadManager.Dtos.MemberProperty;
using SquadManager.Dtos.Members;

namespace SquadManager.Api.Configuration.MapperProfiles;

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

        CreateMap<UpdateMemberRoleDto, MemberProperty>();

        CreateMap<Member, MemberWithPropertiesDto>();
    }
}
