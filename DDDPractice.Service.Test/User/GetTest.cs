using Moq;
using Xunit;
using DDDPractice.Domain.DTOs.User;
using DDDPractice.Domain.Interfaces.Services.User;

#nullable disable
namespace DDDPractice.Service.Test.User
{
    public class GetTest : UserTest
    {
        private IUserService _userService;

        private Mock<IUserService> _userServiceMock;

        [Fact]
        public async Task Get_By_id()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.GetById(UserId)).ReturnsAsync(userDto);
            _userService = _userServiceMock.Object;

            var result = await _userService.GetById(UserId);
            Assert.NotNull(result);
            Assert.True(result.Id == UserId);
            Assert.Equal(NameUser, result.Name);

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _userService = _userServiceMock.Object;

            var _record = await _userService.GetById(UserId);
            Assert.Null(_record);
        }
    }
}