using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using DDDPractice.Domain.DTOs.User;
using DDDPractice.Application.Controllers;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Application.Test.User.WhenRequestGet
{
    public class Return_BadRequest
    {
        private UserController? _userController;

        [Fact]
        public async Task Is_Possible_Invoke_Get_Controller()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            serviceMock.Setup(u => u.GetById(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email
                }
            );
            _userController = new UserController(serviceMock.Object);
            _userController.ModelState.AddModelError("Id", "Invalid Format!");
            var result = await _userController.GetById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}