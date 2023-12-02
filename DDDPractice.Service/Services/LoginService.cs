using System.Security.Claims;
using DDDPractice.Domain.DTOs;
using System.Security.Principal;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Security;
using DDDPractice.Domain.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using DDDPractice.Domain.Interfaces.Services.User;

#nullable disable
namespace DDDPractice.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly IConfiguration _configuration;

        public LoginService(IUserRepository userRepository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDTO loginDTO)
        {
            var baseUser = new UserEntity();
            if(loginDTO is not null && !string.IsNullOrWhiteSpace(loginDTO.Email))
            {
                baseUser = await _userRepository.FindByLogin(loginDTO.Email);
                if(baseUser is null)
                    return new {Authenticated = false, Message = "Fail authenticate!"};
                else
                {
                    ClaimsIdentity identity = new
                    (
                        new GenericIdentity(loginDTO.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, loginDTO.Email),
                        }
                    );
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);
                    var handler = new JwtSecurityTokenHandler();
                    var token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, loginDTO);
                }
            }
            else
                throw new ArgumentNullException(nameof(loginDTO), "Invalid login or not exist");
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securityToken);
            return token;
        }

        private static object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDTO loginDTO)
        {
            return new
            {
                Authenticated = true,
                Create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                UserName = loginDTO.Email,
                Message = "User logged in successfully!"
            };
        }
    }
}