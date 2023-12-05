#nullable disable
namespace DDDPractice.Domain.Models
{
    /// <summary>
    /// The user model.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// The id.
        /// </summary>
        private Guid _id;
        /// <summary>
        /// Gets or Sets the id.
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// The name.
        /// </summary>
        private string _name;
        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// The email.
        /// </summary>
        private string _email;
        /// <summary>
        /// Gets or Sets the email.
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// The create at.
        /// </summary>
        private DateTime? _createAt;
        /// <summary>
        /// Gets or Sets the create at.
        /// </summary>
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        /// <summary>
        /// The update at.
        /// </summary>
        private DateTime _updateAt;
        /// <summary>
        /// Gets or Sets the update at.
        /// </summary>
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
        
    }
}