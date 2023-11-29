using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Repository;
using DDDPractice.Domain.Interfaces.Services.User;

#nullable disable
namespace DDDPractice.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> FindByLogin(UserEntity userEntity)
        {
            var baseUser = new UserEntity();
            if(baseUser is not null && !string.IsNullOrWhiteSpace(userEntity.Email))
                return await _userRepository.FindByLogin(userEntity.Email);
            else
                throw new ArgumentNullException(nameof(userEntity), "Invalid login or not exist");
        }
    }
}