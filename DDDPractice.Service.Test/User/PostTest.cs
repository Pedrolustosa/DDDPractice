using Moq;
using Xunit;
using DDDPractice.Domain.Interfaces.Services.User;

#nullable disable
namespace DDDPractice.Service.Test.User
{
    public class PostTest : UserTest
    {
        private IUserService _userService;

        private Mock<IUserService> _userServiceMock;

        [Fact]
        public async Task Post_User()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _userService = _userServiceMock.Object;

            var result = await _userService.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NameUser, result.Name);
            Assert.Equal(EmailUser, result.Email);
        }
    }
}