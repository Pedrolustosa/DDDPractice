using DDDPractice.Domain.DTOs.User;
using DDDPractice.Domain.Entities;

namespace DDDPractice.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> GetById(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDtoCreateResult> Post(UserDto userEntity);
        Task<UserDtoUpdateResult> Put(UserDto userEntity);
        Task<bool> Delete(Guid id);
    }
}