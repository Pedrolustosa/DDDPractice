using System.ComponentModel.DataAnnotations;

#nullable disable
namespace DDDPractice.Domain.DTOs.User
{
    /// <summary>
    /// The user dto update.
    /// </summary>
    public class UserDtoUpdate
    {
        /// <summary>
        /// Gets or Sets the id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets the email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Name { get; set; }
    }
}