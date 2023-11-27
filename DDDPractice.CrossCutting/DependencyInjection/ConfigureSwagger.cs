using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDPractice.CrossCutting.DependencyInjection
{
    public static class ConfigureSwagger
    {
        public static IServiceCollection ConfigureDependenciesSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DDDPratice.API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Pedro Lustosa",
                        Email = "pedroeternalss@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/pedrolustosaengineer/")
                    }
                });
            });
            return services;
        }
    }
}