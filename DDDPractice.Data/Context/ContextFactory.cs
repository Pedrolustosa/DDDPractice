using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DDDPractice.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DDDPracticeContext>
    {
        public DDDPracticeContext CreateDbContext(string[] args)
        {
            //Used to create migrations
            var connectionString = "Server=DESKTOP-4CL4V9V;Database=DDDPracticeDB;Integrated Security=true;TrustServerCertificate=True";
            var optionsBuilder = new DbContextOptionsBuilder<DDDPracticeContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new DDDPracticeContext(optionsBuilder.Options);
        }
    }
}