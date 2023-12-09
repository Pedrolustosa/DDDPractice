using Moq;
using Xunit;
using DDDPractice.Domain.DTOs.User;
using DDDPractice.Domain.Interfaces.Services.User;

#nullable disable
namespace DDDPractice.Service.Test.User
{
    public class GetAllTest : UserTest
    {
        private IUserService _userService;

        private Mock<IUserService> _userServiceMock;

        [Fact]
        public async Task Get_All_Users()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.GetAll()).ReturnsAsync(listUserDto);
            _userService = _userServiceMock.Object;

            var result = await _userService.GetAll();
            Assert.NotNull(result);
            Assert.True(result?.Count() > 0);

            var _listResult = new List<UserDto>();
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable());
            _userService = _userServiceMock.Object;

            var _resultEmpty = await _userService.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);

        }
    }
}