using AutoMapper;
using DDDPractice.Service.Services;
using DDDPractice.CrossCutting.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
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