using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using DDDPractice.Domain.DTOs.User;
using DDDPractice.Application.Controllers;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Application.Test.User.WhenRequestUpdate
{
    public class Return_BadRequest
    {
        private UserController? _userController;

        [Fact]
        public async Task Is_Possible_Invoke_Post_Controller()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(u => u.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _userController = new UserController(serviceMock.Object);
            _userController.ModelState.AddModelError("Email", "Is required!");

            var userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await _userController.Put(userDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_userController.ModelState.IsValid);
        }
    }
}