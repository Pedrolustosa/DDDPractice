using DDDPractice.Data.Context;
using DDDPractice.Data.Repository;
using DDDPractice.Domain.Interfaces;
using DDDPractice.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using DDDPractice.Data.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDPractice.CrossCutting.DependencyInjection
{
    /// <summary>
    /// The configure repository.
    /// </summary>
    public static class ConfigureRepository
    {
        /// <summary>
        /// Configures the dependencies repository.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureDependenciesRepository(this IServiceCollection services, IConfiguration configuration){
            services.AddDbContext<DDDPracticeContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(DDDPracticeContext).Assembly.FullName)));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserImplementations>();
            return services;
        }
    }
}