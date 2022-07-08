using AutoMapper;
using SquadManager.Web.Configurations.MapperProfiles;


namespace SquadManager.Web.Configurations;

public static class AutoMapperConfiguration
{
    public static void AddAutomapper(this IServiceCollection services)
    {
        var mappingConfiguration = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MemberProfiles());
            mc.AddProfile(new DogProfiles());
        });

        IMapper mapper = mappingConfiguration.CreateMapper();
        services.AddSingleton(mapper);
    }
}
