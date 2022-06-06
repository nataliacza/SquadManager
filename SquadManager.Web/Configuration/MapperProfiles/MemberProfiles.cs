﻿using AutoMapper;
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

        CreateMap<CreateMemberDto, Member>()
            .ReverseMap();

        CreateMap<MemberBasicsDto, Member>()
            .ReverseMap();

        CreateMap<MemberPropertyDto, MemberProperty>()
            .ReverseMap();

        CreateMap<MemberDogDto, Dog>()
            .ReverseMap();
    }
}
