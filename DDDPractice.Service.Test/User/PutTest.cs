using Moq;
using Xunit;
using DDDPractice.Domain.Interfaces.Services.User;

#nullable disable
namespace DDDPractice.Service.Test.User
{
    public class PutTest : UserTest
    {
        private IUserService _userService;

        private Mock<IUserService> _userServiceMock;

        [Fact]
        public async Task Put_User()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _userService = _userServiceMock.Object;

            var resultCreate = await _userService.Post(userDtoCreate);
            Assert.NotNull(resultCreate);
            Assert.Equal(NameUser, resultCreate.Name);
            Assert.Equal(EmailUser, resultCreate.Email);

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _userService = _userServiceMock.Object;

            var resultUpdate = await _userService.Put(userDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(UserId.ToString(), resultUpdate.Id.ToString());
            Assert.Equal(NameUserEdited, resultUpdate.Name);
            Assert.Equal(EmailUserEdited, resultUpdate.Email);
        }
    }
}