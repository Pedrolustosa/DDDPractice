#nullable disable
using System.ComponentModel.DataAnnotations;

namespace DDDPractice.Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Email format is incorrect!")]
        public string Email { get; set; }
    }
}