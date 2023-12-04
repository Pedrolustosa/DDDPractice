using System.ComponentModel.DataAnnotations;

namespace DDDPractice.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value is null ? DateTime.UtcNow : value); }
        }
        
        public DateTime? UpdateAt { get; set; }
    }
}