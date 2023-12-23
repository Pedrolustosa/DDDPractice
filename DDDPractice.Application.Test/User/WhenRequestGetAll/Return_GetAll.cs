using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using DDDPractice.Domain.DTOs.User;
using DDDPractice.Application.Controllers;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Application.Test.User.WhenRequestGetAll
{
    public class Return_GetAll
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
            var result = await _userController.GetAll();
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.True(resultValue?.Count() >= 1);
        }
    }
}