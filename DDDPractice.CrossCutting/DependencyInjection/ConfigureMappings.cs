using AutoMapper;
using DDDPractice.CrossCutting.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDPractice.CrossCutting.DependencyInjection
{
    /// <summary>
    /// The configure mappings.
    /// </summary>
    public static class ConfigureMappings
    {
        /// <summary>
        /// Configures the dependencies mappings.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureDependenciesMappings(this IServiceCollection services, IConfiguration configuration)
        {
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