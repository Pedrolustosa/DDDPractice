using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DDDPractice.Data.Context
{
    /// <summary>
    /// The context factory.
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<DDDPracticeContext>
    {
        /// <summary>
        /// Creates the db context.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>A DDDPracticeContext.</returns>
        public DDDPracticeContext CreateDbContext(string[] args)
        {
            //Used to create migrations
            var connectionString = "Server=DESKTOP-4CL4V9V;Database=DDDPracticeDB;Integrated Security=true;TrustServerCertificate=True";
            var optionsBuilder = new DbContextOptionsBuilder<DDDPracticeContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new DDDPracticeContext(optionsBuilder.Options);
        }
    }
}