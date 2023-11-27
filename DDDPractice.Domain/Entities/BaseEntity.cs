using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DDDPractice.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        private DateTime? _createAt;
        [JsonIgnore]
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value is null ? DateTime.UtcNow : value); }
        }
        
        [JsonIgnore]
        public DateTime? UpdateAt { get; set; }
    }
}