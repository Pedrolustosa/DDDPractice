using AutoMapper;
using DDDPractice.Service.Services;
using DDDPractice.CrossCutting.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DDDPractice.Domain.Interfaces.Services.User;

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
        public static IServiceCollection ConfigureDependenciesService(this IServiceCollection services, IConfiguration configuration){
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