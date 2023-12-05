using DDDPractice.Data.Mapping;
using DDDPractice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDPractice.Data.Context
{
    /// <summary>
    /// The DDD practice context.
    /// </summary>
    public class DDDPracticeContext : DbContext
    {
        public DDDPracticeContext(DbContextOptions<DDDPracticeContext> dbContextOptions) : base (dbContextOptions) { }

        public DbSet<UserEntity>? userEntities;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}