using DDDPractice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDPractice.Data.Mapping
{
    /// <summary>
    /// The user map.
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email)
                   .IsUnique();
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(60);
            builder.Property(u => u.Email)
                   .HasMaxLength(100);
        }
    }
}