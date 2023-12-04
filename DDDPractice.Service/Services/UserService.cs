using AutoMapper;
using DDDPractice.Domain.DTOs.User;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces;
using DDDPractice.Domain.Interfaces.Services.User;
using DDDPractice.Domain.Models;

namespace DDDPractice.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _iMapper;

        public UserService(IRepository<UserEntity> repository, IMapper iMapper)
        {
            _repository = repository;
            _iMapper = iMapper;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.SelectAllAsync();
            return _iMapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _iMapper.Map<UserDto>(entity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate userEntity)
        {
            var model = _iMapper.Map<UserModel>(userEntity); 
            var entity = _iMapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _iMapper.Map<UserDtoCreateResult>(result);;
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate userEntity)
        {
            var model = _iMapper.Map<UserModel>(userEntity); 
            var entity = _iMapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _iMapper.Map<UserDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}