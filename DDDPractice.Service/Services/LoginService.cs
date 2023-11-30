using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Repository;
using DDDPractice.Domain.Interfaces.Services.User;
using DDDPractice.Domain.DTOs;

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

        public async Task<object> FindByLogin(LoginDTO loginDTO)
        {
            var baseUser = new LoginDTO();
            if(baseUser is not null && !string.IsNullOrWhiteSpace(loginDTO.Email))
                return await _userRepository.FindByLogin(loginDTO.Email);
            else
                throw new ArgumentNullException(nameof(loginDTO), "Invalid login or not exist");
        }
    }
}