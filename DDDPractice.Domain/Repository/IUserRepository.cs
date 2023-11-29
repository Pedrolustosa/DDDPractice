using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces;

namespace DDDPractice.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}