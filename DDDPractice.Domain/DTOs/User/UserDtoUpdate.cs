using System.ComponentModel.DataAnnotations;

#nullable disable
namespace DDDPractice.Domain.DTOs.User
{
    public class UserDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        public string Name { get; set; }
    }
}