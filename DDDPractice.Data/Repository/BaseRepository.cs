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
                throw ex.GetBaseException();
            }
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(e => e.Id.Equals(entity.Id));
                if(result is null) throw new NullReferenceException();
                entity.UpdateAt = DateTime.UtcNow;
                entity.CreateAt = result.CreateAt;
                _dDDPracticeContext.Entry(result).CurrentValues.SetValues(entity);
                await _dDDPracticeContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }

            return entity;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result= await _dbSet.SingleOrDefaultAsync(u => u.Id.Equals(id));
                if(result is null) return false;
                _dbSet.Remove(result);
                await _dDDPracticeContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }
    }
}