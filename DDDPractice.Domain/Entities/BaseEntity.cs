using System.ComponentModel.DataAnnotations;

namespace DDDPractice.Domain.Entities
{
    /// <summary>
    /// The base entity.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or Sets the id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

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
            set { _createAt = (value is null ? DateTime.UtcNow : value); }
        }

        /// <summary>
        /// Gets or Sets the update at.
        /// </summary>
        public DateTime? UpdateAt { get; set; }
    }
}