using AutoMapper;
using DDDPractice.Service.Services;
using DDDPractice.CrossCutting.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DDDPractice.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DDDPractice.CrossCutting.DependencyInjection
{
    /// <summary>
    /// The configure service.
    /// </summary>
    public static class ConfigureService
    {
        /// <summary>
        /// Configures the dependencies service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureDependenciesService(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment){
            if(webHostEnvironment.IsEnvironment("Testing"))
            {
                Environment.SetEnvironmentVariable("DB_CONNECTION", "Server=DESKTOP-4CL4V9V;Database=DDDPracticeDB_Integration;Integrated Security=true;TrustServerCertificate=True");
                Environment.SetEnvironmentVariable("DATABASE", "SQLServer");
                Environment.SetEnvironmentVariable("MIGRATION", "APLICAR");
                Environment.SetEnvironmentVariable("Audience", "Audience");
                Environment.SetEnvironmentVariable("Issuer", "Issuer");
                Environment.SetEnvironmentVariable("Seconds", "28800");
            }

            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            
            //Mappings
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });
            IMapper iMapper = config.CreateMapper();
            services.AddSingleton(iMapper);

            return services;
        }
    }
}