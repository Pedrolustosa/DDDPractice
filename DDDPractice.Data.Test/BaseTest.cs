using DDDPractice.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDDPractice.Data.Test;

/// <summary>
/// The base test.
/// </summary>
public abstract class BaseTest
{
    public class DbTest : IDisposable
    {
        /// <summary>
        /// The db name.
        /// </summary>
        private readonly string dbName = $"dbApiTest {Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        public ServiceProvider? ServiceProvider {get; private set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="DbTest"/> class.
        /// </summary>
        public DbTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DDDPracticeContext>(o => o.UseSqlServer($"Server=DESKTOP-4CL4V9V;Database={dbName};Integrated Security=true;TrustServerCertificate=True"), 
                                                                    ServiceLifetime.Transient);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            using var context = ServiceProvider.GetService<DDDPracticeContext>();
            context?.Database.EnsureCreated();
        }

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            using var context = ServiceProvider?.GetService<DDDPracticeContext>();
            context?.Database.EnsureDeleted();
        }
    }
}