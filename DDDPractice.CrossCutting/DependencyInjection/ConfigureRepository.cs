using DDDPractice.Data.Context;
using DDDPractice.Data.Implementations;
using DDDPractice.Data.Repository;
using DDDPractice.Domain.Interfaces;
using DDDPractice.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDPractice.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static IServiceCollection ConfigureDependenciesRepository(this IServiceCollection services, IConfiguration configuration){
            services.AddDbContext<DDDPracticeContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(DDDPracticeContext).Assembly.FullName)));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserImplementations>();
            return services;
        }
    }
}