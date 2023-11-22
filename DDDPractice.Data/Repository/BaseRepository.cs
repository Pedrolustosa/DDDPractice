using DDDPractice.Data.Context;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDDPractice.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DDDPracticeContext _dDDPracticeContext;
        private DbSet<T> _dbSet;

        public BaseRepository(DDDPracticeContext dDDPracticeContext)
        {
            _dDDPracticeContext = dDDPracticeContext;
            _dbSet = dDDPracticeContext.Set<T>();
        }

        public Task<IEnumerable<T>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if(entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();
                entity.CreateAt = DateTime.UtcNow;
                _dbSet.Add(entity);
                await _dDDPracticeContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}