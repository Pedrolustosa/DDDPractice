using DDDPractice.Data.Context;
using DDDPractice.Data.Repository;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Repository;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace DDDPractice.Data.Implementations
{
    public class UserImplementations : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DbSet<UserEntity> _dbSet;
        public UserImplementations(DDDPracticeContext dDDPracticeContext) : base(dDDPracticeContext)
        {
            _dbSet = dDDPracticeContext.Set<UserEntity>();
        }
        public async Task<UserEntity> FindByLogin(string email) => await _dbSet.FirstOrDefaultAsync(u => u.Email.Equals(email));
    }
}