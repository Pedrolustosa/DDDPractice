using Xunit;
using AutoMapper;
using DDDPractice.Domain.Models;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.DTOs.User;

namespace DDDPractice.Service.Test.AutoMapper
{
    public class UserMapper : BaseTestService
    {
        [Fact]
        public void User_Mapper_Models()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<UserEntity>();
            for (int i = 0; i < 3; i++)
            {
                var userEntity = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(userEntity);
            };

            //Model > Entity
            var entity = IMapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity > DTO
            var userDto = IMapper.Map<UserDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.Email, entity.Email);
            Assert.Equal(userDto.CreateAt, entity.CreateAt);

            // List UserDTO
            var listDto = IMapper.Map<List<UserDto>>(listEntity);
            Assert.True(listDto.Count == listEntity.Count);
            for (int i = 0; i < listDto.Count; i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Name, listEntity[i].Name);
                Assert.Equal(listDto[i].Email, listEntity[i].Email);
                Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
            }
            
            // Entity > UserDtoCreateResult
            var userDtoCreateResult = IMapper.Map<UserDtoCreateResult>(entity);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.Name, entity.Name);
            Assert.Equal(userDtoCreateResult.Email, entity.Email);
            Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);

            var userDtoUpdateResult = IMapper.Map<UserDtoUpdateResult>(entity);
            Assert.Equal(userDtoUpdateResult.Id, entity.Id);
            Assert.Equal(userDtoUpdateResult.Name, entity.Name);
            Assert.Equal(userDtoUpdateResult.Email, entity.Email);
            Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //DTO > Model
            var userModel = IMapper.Map<UserDto>(userDto);
            Assert.Equal(userModel.Id, model.Id);
            Assert.Equal(userModel.Name, model.Name);
            Assert.Equal(userModel.Email, model.Email);
            Assert.Equal(userModel.CreateAt, model.CreateAt);

            //DTO > UserDtoCreate
            var userDtoCreate = IMapper.Map<UserDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, model.Name);
            Assert.Equal(userDtoCreate.Email, model.Email);

            //DTO > UserDtoUpdate
            var userDtoUpdate = IMapper.Map<UserDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, model.Id);
            Assert.Equal(userDtoUpdate.Name, model.Name);
            Assert.Equal(userDtoUpdate.Email, model.Email);
        }
    }
}