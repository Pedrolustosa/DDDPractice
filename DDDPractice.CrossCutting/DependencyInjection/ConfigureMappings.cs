using AutoMapper;
using DDDPractice.CrossCutting.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDPractice.CrossCutting.DependencyInjection
{
    public static class ConfigureMappings
    {
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