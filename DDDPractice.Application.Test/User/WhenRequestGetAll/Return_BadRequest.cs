using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using DDDPractice.Domain.DTOs.User;
using DDDPractice.Application.Controllers;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Application.Test.User.WhenRequestGetAll
{
    public class Return_BadRequest
    {
        private UserController? _userController;

        [Fact]
        public async Task Is_Possible_Invoke_GetAll_Controller()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(u => u.GetAll()).ReturnsAsync(
                new List<UserDto>
                {
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email()
                    }
                }
            );
            _userController = new UserController(serviceMock.Object);
            _userController.ModelState.AddModelError("Id", "Invalid Format!");
            var result = await _userController.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}