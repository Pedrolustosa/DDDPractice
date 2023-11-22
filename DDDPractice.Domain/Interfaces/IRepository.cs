using DDDPractice.Domain.Entities;

namespace DDDPractice.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity 
    {
        Task<bool> ExistAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<T>> SelectAllAsync();
    }
}