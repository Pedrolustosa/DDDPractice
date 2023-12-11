using Moq;
using Xunit;
using DDDPractice.Domain.DTOs;
using DDDPractice.Domain.Interfaces.Services.User;

#nullable disable
namespace DDDPractice.Service.Test.Login
{
    public class LoginTest
    {
        private ILoginService _loginService;

        private Mock<ILoginService> _loginServiceMock;

        [Fact]
        public async Task Find_By_Login()
        {
            var email = Faker.Internet.Email();
            var objectReturn = new
            {
                Authenticated = true,
                Create = DateTime.UtcNow,
                Expiration = DateTime.UtcNow.AddHours(2),
                AccessToken = Guid.NewGuid(),
                UserName = email,
                Message = "User logged in successfully!"
            };

            var loginDto = new LoginDTO
            {
                Email = email
            };

            _loginServiceMock = new Mock<ILoginService>();
            _loginServiceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objectReturn);
            _loginService = _loginServiceMock.Object;

            var result = await _loginService.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}