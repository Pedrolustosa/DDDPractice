#nullable disable
using DDDPractice.Domain.Validation;

namespace DDDPractice.Domain.Entities
{
    /// <summary>
    /// The user entity.
    /// </summary>
    public class UserEntity : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserEntity"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        public UserEntity(string name, string email)
        {
            ValidateUser(name, email);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserEntity"/> class.
        /// </summary>
        public UserEntity(){ }

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        private void ValidateUser(string name, string email)
        {
            DomainExceptionValidation.When(name is null || name.Length <= 0, "The Name must not be null or lenght less than or equal to 0 characters");
            
            Name = name;
            Email = email;
        }

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the email.
        /// </summary>
        public string Email { get; set; }
    }

    
}