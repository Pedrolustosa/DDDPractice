using DDDPractice.Domain.Entities;

namespace DDDPractice.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> GetById(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> Post(UserEntity userEntity);
        Task<UserEntity> Put(UserEntity userEntity);
        Task<bool> Delete(Guid id);
    }
}