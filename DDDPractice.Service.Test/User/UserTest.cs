using DDDPractice.Domain.DTOs.User;

#nullable disable
namespace DDDPractice.Service.Test.User
{
    public class UserTest
    {
        public static string NameUser { get; set; }
        public string EmailUser { get; set; }
        public static string NameUserEdited { get; set; }
        public string EmailUserEdited { get; set; }
        public static Guid UserId {get; set;}

        public UserDto userDto;
        public List<UserDto> listUserDto = new();
        public UserDtoCreate userDtoCreate;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdateResult userDtoUpdateResult;

        public UserTest()
        {
            UserId = Guid.NewGuid();
            NameUser = Faker.Name.FullName();
            EmailUser = Faker.Internet.Email();
            NameUserEdited = Faker.Name.FullName();
            EmailUserEdited = Faker.Internet.Email();

            for(int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                };
                listUserDto.Add(dto);
            }

            userDto = new UserDto()
            {
                Id = Guid.NewGuid(),
                Name = NameUser,
                Email = EmailUser,
            };

            userDtoCreate = new UserDtoCreate()
            {
                Name = NameUser,
                Email = EmailUser,
            };

            userDtoUpdate = new UserDtoUpdate()
            {
                Id = UserId,
                Name = NameUser,
                Email = EmailUser,
            };

            userDtoCreateResult = new UserDtoCreateResult()
            {
                Id = UserId,
                Name = NameUser,
                Email = EmailUser,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdateResult = new UserDtoUpdateResult()
            {
                Name = NameUser,
                Email = EmailUser,
            };
        }
    }
}