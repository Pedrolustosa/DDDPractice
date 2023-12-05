using DDDPractice.Domain.DTOs.User;

namespace DDDPractice.Domain.Interfaces.Services.User
{
    /// <summary>
    /// The user service interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<UserDto>.]]></returns>
        Task<UserDto> GetById(Guid id);
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<UserDto>>.]]></returns>
        Task<IEnumerable<UserDto>> GetAll();
        /// <summary>
        /// Post a <see cref="UserDtoCreateResult"/>.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns><![CDATA[A Task<UserDtoCreateResult>.]]></returns>
        Task<UserDtoCreateResult> Post(UserDtoCreate userEntity);
        /// <summary>
        /// Puts a <see cref="UserDtoUpdateResult"/>.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns><![CDATA[A Task<UserDtoUpdateResult>.]]></returns>
        Task<UserDtoUpdateResult> Put(UserDtoUpdate userEntity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        Task<bool> Delete(Guid id);
    }
}