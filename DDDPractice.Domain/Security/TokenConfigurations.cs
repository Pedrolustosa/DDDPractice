#nullable disable
namespace DDDPractice.Domain.Security
{
    /// <summary>
    /// The token configurations.
    /// </summary>
    public class TokenConfigurations
    {
        /// <summary>
        /// Gets or Sets the audience.
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Gets or Sets the issuer.
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Gets or Sets the seconds.
        /// </summary>
        public int Seconds { get; set; }
    }
}