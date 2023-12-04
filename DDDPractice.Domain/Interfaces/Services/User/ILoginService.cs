using DDDPractice.Domain.DTOs;

namespace DDDPractice.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDTO loginDTO);   
    }
}