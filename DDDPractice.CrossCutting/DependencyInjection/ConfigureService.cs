using DDDPractice.Domain.Security;
using DDDPractice.Service.Services;
using Microsoft.Extensions.Options;
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

            //Token
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);
            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);
            return services;
        }
    }
}