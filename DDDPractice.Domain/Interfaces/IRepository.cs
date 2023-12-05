using DDDPractice.Domain.Entities;

namespace DDDPractice.Domain.Interfaces
{
    /// <summary>
    /// The repository interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        Task<bool> ExistAsync(Guid id);
        /// <summary>
        /// Selects a <see cref="T"/>. asynchronously.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<T>.]]></returns>
        Task<T> SelectAsync(Guid id);
        /// <summary>
        /// Inserts a <see cref="T"/>. asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><![CDATA[A Task<T>.]]></returns>
        Task<T> InsertAsync(T entity);
        /// <summary>
        /// Updates a <see cref="T"/>. asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><![CDATA[A Task<T>.]]></returns>
        Task<T> UpdateAsync(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        Task<bool> DeleteAsync(Guid id);
        /// <summary>
        /// Selects the all asynchronously.
        /// </summary>
        /// <returns><![CDATA[A Task<List<T>>.]]></returns>
        Task<IEnumerable<T>> SelectAllAsync();
    }
}