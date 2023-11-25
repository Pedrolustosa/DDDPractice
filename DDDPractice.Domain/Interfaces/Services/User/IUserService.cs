using DDDPractice.Domain.Entities;

namespace DDDPractice.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> Post(UserEntity userEntity);
        Task<UserEntity> Put(Guid id);
        Task<bool> Delete(Guid id);
    }
}