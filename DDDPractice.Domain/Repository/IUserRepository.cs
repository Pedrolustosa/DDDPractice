using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces;

namespace DDDPractice.Domain.Repository
{
    /// <summary>
    /// The user repository interface.
    /// </summary>
    public interface IUserRepository : IRepository<UserEntity>
    {
        /// <summary>
        /// Find the by login.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns><![CDATA[A Task<UserEntity>.]]></returns>
        Task<UserEntity> FindByLogin(string email);
    }
}