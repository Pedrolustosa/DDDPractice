using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using DDDPractice.Application.Controllers;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Application.Test.User.WhenRequestDelete
{
    public class Return_BadRequest
    {
        private UserController? _userController;

        [Fact]
        public async Task Is_Possible_Invoke_Delete_Controller()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(u => u.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _userController = new UserController(serviceMock.Object);
            _userController.ModelState.AddModelError("Id", "Invalid Format");
            var result = await _userController.Delete(default);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}