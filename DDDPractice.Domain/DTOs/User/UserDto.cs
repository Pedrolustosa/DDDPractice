using System.ComponentModel.DataAnnotations;

#nullable disable
namespace DDDPractice.Domain.DTOs.User
{
    public class UserDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        public string Name { get; set; }
    }
}