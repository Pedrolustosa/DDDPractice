using Xunit;
using System.Net;
using Newtonsoft.Json;
using DDDPractice.Domain.DTOs.User;

#nullable disable
namespace DDDPractice.Integration.Test.User
{
    public class WhenRequestUser : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }

        [Fact]
        public async Task Is_Possible_Invoke_Crud_Controller()
        {
            await AddToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var userDto = new UserDtoCreate()
            {
                Name = _name,
                Email = _email
            };

            //Post
            var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registerPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registerPost.Name);
            Assert.Equal(_email, registerPost.Email);
            Assert.True(registerPost.Id != default);

            //Get All
            response = await client.GetAsync($"{hostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count() > 0);
            Assert.True(listFromJson.Where(r => r.Id == registerPost.Id).Count() == 1);

            var updateUserDto = new UserDtoUpdate()
            {
                Id = registerPost.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };
        }
    }
}
