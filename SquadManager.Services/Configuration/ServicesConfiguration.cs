using Microsoft.Extensions.DependencyInjection;
using SquadManager.Services.Core.Dogs;
using SquadManager.Services.Core.Members;
using SquadManager.Services.Interfaces.Dog;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IMemberCreator, EfMemberCreator>();
        services.AddTransient<IMemberGetter, EfMemberGetter>();
        services.AddTransient<IMemberUpdater, EfMemberUpdater>();
        services.AddTransient<IMemberDeleter, EfMemberDeleter>();

        services.AddTransient<IDogCreator, EfDogCreator>();
        services.AddTransient<IDogGetter, EfDogGetter>();
        services.AddTransient<IDogUpdater, EfDogUpdater>();
        services.AddTransient<IDogDeleter, EfDogDeleter>();

        return services;
    }
}
