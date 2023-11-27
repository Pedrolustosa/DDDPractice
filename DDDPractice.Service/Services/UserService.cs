using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<UserEntity> GetById(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<UserEntity> Post(UserEntity userEntity)
        {
            return await _repository.InsertAsync(userEntity);
        }

        public async Task<UserEntity> Put(UserEntity userEntity)
        {
            return await _repository.UpdateAsync(userEntity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}