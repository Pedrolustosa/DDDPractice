using DDDPractice.Data.Context;
using DDDPractice.Data.Repository;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Repository;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace DDDPractice.Data.Implementations
{
    /// <summary>
    /// The user implementations.
    /// </summary>
    public class UserImplementations : BaseRepository<UserEntity>, IUserRepository
    {
        /// <summary>
        /// The db set.
        /// </summary>
        private readonly DbSet<UserEntity> _dbSet;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserImplementations"/> class.
        /// </summary>
        /// <param name="dDDPracticeContext">The d DD practice context.</param>
        public UserImplementations(DDDPracticeContext dDDPracticeContext) : base(dDDPracticeContext)
        {
            _dbSet = dDDPracticeContext.Set<UserEntity>();
        }
        /// <summary>
        /// Find the by login.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns><![CDATA[A Task<UserEntity>.]]></returns>
        public async Task<UserEntity> FindByLogin(string email) => await _dbSet.FirstOrDefaultAsync(u => u.Email.Equals(email));
    }
}