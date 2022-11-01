using JobPortalService.Library.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace JobPortalService.Library.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class AuthDependencyInjectionExtension
    {
        public static void ConfigureJWTAuthenticationServiceDI(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
