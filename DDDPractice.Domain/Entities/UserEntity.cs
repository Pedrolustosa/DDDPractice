#nullable disable
using DDDPractice.Domain.Validation;

namespace DDDPractice.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string name, string email)
        {
            ValidateUser(name, email);
        }

        private void ValidateUser(string name, string email)
        {
            DomainExceptionValidation.When(name is null || name.Length <= 0, "The Name must not be null or lenght less than or equal to 0 characters");
            
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        
        public string Email { get; set; }
    }

    
}