using DDDPractice.Data.Context;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDDPractice.Data.Repository
{
    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The d dd practice context.
        /// </summary>
        private readonly DDDPracticeContext _dDDPracticeContext;
        /// <summary>
        /// The db set.
        /// </summary>
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="dDDPracticeContext">The d DD practice context.</param>
        public BaseRepository(DDDPracticeContext dDDPracticeContext)
        {
            _dDDPracticeContext = dDDPracticeContext;
            _dbSet = dDDPracticeContext.Set<T>();
        }

        /// <summary>
        /// Selects the all asynchronously.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns><![CDATA[A Task<List<T>>.]]></returns>
        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            try
            {
                return await _dbSet.AsNoTracking().ToListAsync() ?? throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        /// <summary>
        /// Selects a <see cref="T"/>. asynchronously.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns><![CDATA[A Task<T>.]]></returns>
        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dbSet.AsNoTracking().SingleOrDefaultAsync(u => u.Id.Equals(id)) ?? throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        public async Task<bool> ExistAsync(Guid id) => await _dbSet.AsNoTracking().AnyAsync(u => u.Id.Equals(id));

        /// <summary>
        /// Inserts a <see cref="T"/>. asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><![CDATA[A Task<T>.]]></returns>
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

        /// <summary>
        /// Updates a <see cref="T"/>. asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns><![CDATA[A Task<T>.]]></returns>
        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(e => e.Id.Equals(entity.Id)) ?? throw new NullReferenceException();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result= await _dbSet.AsNoTracking().SingleOrDefaultAsync(u => u.Id.Equals(id));
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