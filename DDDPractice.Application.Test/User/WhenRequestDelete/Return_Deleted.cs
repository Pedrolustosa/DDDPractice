using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using DDDPractice.Application.Controllers;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Application.Test.User.WhenRequestDelete
{
    public class Return_Deleted
    {
        private UserController? _userController;

        [Fact]
        public async Task Is_Possible_Invoke_Delete_Controller()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(u => u.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _userController = new UserController(serviceMock.Object);
            var result = await _userController.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((bool)resultValue);
        }
    }
}