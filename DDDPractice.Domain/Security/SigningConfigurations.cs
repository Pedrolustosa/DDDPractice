using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

#nullable disable
namespace DDDPractice.Domain.Security
{
    /// <summary>
    /// The signing configurations.
    /// </summary>
    public class SigningConfigurations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SigningConfigurations"/> class.
        /// </summary>
        public SigningConfigurations()
        {
            using var provider = new RSACryptoServiceProvider(2048);
            Key = new RsaSecurityKey(provider.ExportParameters(true));
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }

        /// <summary>
        /// Gets or Sets the key.
        /// </summary>
        public SecurityKey Key { get; set; }

        /// <summary>
        /// Gets or Sets the signing credentials.
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
    }
}