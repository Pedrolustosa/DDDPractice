using DDDPractice.Domain.DTOs;

namespace DDDPractice.Domain.Interfaces.Services.User
{
    /// <summary>
    /// The login service interface.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Find the by login.
        /// </summary>
        /// <param name="loginDTO">The login DTO.</param>
        /// <returns><![CDATA[A Task<object>.]]></returns>
        Task<object> FindByLogin(LoginDTO loginDTO);   
    }
}