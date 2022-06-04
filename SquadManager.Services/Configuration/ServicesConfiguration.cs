using Microsoft.Extensions.DependencyInjection;
using SquadManager.Services.Core.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Configuration;
public static class ServicesConfiguration
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IMemberCreator, EfMemberCreator>();

    }
}
