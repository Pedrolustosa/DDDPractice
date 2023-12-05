#nullable disable
namespace DDDPractice.Domain.DTOs.User
{
    /// <summary>
    /// The user dto update result.
    /// </summary>
    public class UserDtoUpdateResult
    {
        /// <summary>
        /// Gets or Sets the id.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets the email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or Sets the update at.
        /// </summary>
        public DateTime UpdateAt { get; set; }
    }
}