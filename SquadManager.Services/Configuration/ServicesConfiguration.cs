using Microsoft.Extensions.DependencyInjection;
using SquadManager.Services.Core.Dogs;
using SquadManager.Services.Core.Members;
using SquadManager.Services.Interfaces.Dog;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Configuration;
public static class ServicesConfiguration
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IMemberCreator, EfMemberCreator>();
        services.AddScoped<IDogCreator, EfDogCreator>();

        services.AddScoped<IMemberGetter, EfMemberGetter>();
        services.AddScoped<IDogGetter, EfDogGetter>();

        services.AddScoped<IMemberUpdater, EfMemberUpdater>();

        services.AddScoped<IMemberDeleter, EfMemberDeleter>();
        
    }
}
