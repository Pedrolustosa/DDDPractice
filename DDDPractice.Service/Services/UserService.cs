using AutoMapper;
using DDDPractice.Domain.DTOs.User;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces;
using DDDPractice.Domain.Interfaces.Services.User;
using DDDPractice.Domain.Models;

namespace DDDPractice.Service.Services
{
    /// <summary>
    /// The user service.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IRepository<UserEntity> _repository;
        /// <summary>
        /// The i mapper.
        /// </summary>
        private readonly IMapper _iMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="iMapper">The i mapper.</param>
        public UserService(IRepository<UserEntity> repository, IMapper iMapper)
        {
            _repository = repository;
            _iMapper = iMapper;
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<UserDto>>.]]></returns>
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.SelectAllAsync();
            return _iMapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<UserDto>.]]></returns>
        public async Task<UserDto> GetById(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _iMapper.Map<UserDto>(entity);
        }

        /// <summary>
        /// Post a <see cref="UserDtoCreateResult"/>.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns><![CDATA[A Task<UserDtoCreateResult>.]]></returns>
        public async Task<UserDtoCreateResult> Post(UserDtoCreate userEntity)
        {
            var model = _iMapper.Map<UserModel>(userEntity); 
            var entity = _iMapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _iMapper.Map<UserDtoCreateResult>(result);;
        }

        /// <summary>
        /// Puts a <see cref="UserDtoUpdateResult"/>.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns><![CDATA[A Task<UserDtoUpdateResult>.]]></returns>
        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate userEntity)
        {
            var model = _iMapper.Map<UserModel>(userEntity); 
            var entity = _iMapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _iMapper.Map<UserDtoUpdateResult>(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}