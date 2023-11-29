using DDDPractice.Domain.Entities;

namespace DDDPractice.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
     Task<object> FindByLogin(UserEntity userEntity);   
    }
}