

#nullable disable
using DDDPractice.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace DDDPractice.Service.Test.User
{
    public class DeleteTest : UserTest
    {
        private IUserService _userService;

        private Mock<IUserService> _userServiceMock;

        [Fact]
        public async Task Delete_USer()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Delete(UserId)).ReturnsAsync(true);
            _userService = _userServiceMock.Object;

            var resultRemove = await _userService.Delete(UserId);
            Assert.True(resultRemove);

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _userService = _userServiceMock.Object;

            resultRemove = await _userService.Delete(Guid.NewGuid());
            Assert.False(resultRemove);
        }
    }
}