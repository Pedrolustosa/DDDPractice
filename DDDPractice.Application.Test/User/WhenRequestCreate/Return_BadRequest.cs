using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using DDDPractice.Domain.DTOs.User;
using DDDPractice.Application.Controllers;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Application.Test.User.WhenRequestCreate
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

            serviceMock.Setup(u => u.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );

            _userController = new UserController(serviceMock.Object);
            _userController.ModelState.AddModelError("Name", "Required!");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(url => url.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _userController.Url = url.Object;

            var userDtoCreate = new UserDtoCreate
            {
                Name = name,
                Email = email
            };

            var result = await _userController.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}