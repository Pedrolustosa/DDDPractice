using DDDPractice.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureDependenciesService(this IServiceCollection services, IConfiguration configuration){
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            return services;
        }
    }
}