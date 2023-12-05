#nullable disable
using System.ComponentModel.DataAnnotations;

namespace DDDPractice.Domain.DTOs
{
    /// <summary>
    /// The login DTO.
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Gets or Sets the email.
        /// </summary>
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Email format is incorrect!")]
        public string Email { get; set; }
    }
}