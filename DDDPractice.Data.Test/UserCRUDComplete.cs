using Xunit;
using DDDPractice.Data.Context;
using DDDPractice.Domain.Entities;
using DDDPractice.Data.Implementations;
using static DDDPractice.Data.Test.BaseTest;
using Microsoft.Extensions.DependencyInjection;

#nullable disable
namespace DDDPractice.Data.Test
{
    /// <summary>
    /// The user CRUD complete.
    /// </summary>
    public class UserCRUDComplete : BaseTest, IClassFixture<DbTest>
    {
        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly ServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCRUDComplete"/> class.
        /// </summary>
        /// <param name="dbTest">The db test.</param>
        public UserCRUDComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        /// <summary>
        /// Users the insertion successful.
        /// </summary>
        /// <returns>A Task.</returns>
        [Fact(DisplayName = "User Insertion")]
        [Trait("Insert", "UserEntity")]
        public async Task User_Insertion_Successful()
        {
            using var context = _serviceProvider.GetService<DDDPracticeContext>();
            UserImplementations _repository = new(context);
            UserEntity _entity = new()
            {
                Name = Faker.Internet.Email(),
                Email = Faker.Name.FullName(),
            };
            var _createdRecord = await _repository.InsertAsync(_entity);
            Assert.NotNull(_createdRecord);
            Assert.Equal(_entity.Name, _createdRecord.Name);
            Assert.Equal(_entity.Email, _createdRecord.Email);
            Assert.False(_createdRecord.Id == Guid.Empty);

            _entity.Name = Faker.Name.First();
            var _updateRecord = await _repository.UpdateAsync(_entity);
            Assert.NotNull(_updateRecord);
            Assert.Equal(_entity.Name, _updateRecord.Name);
            Assert.Equal(_entity.Email, _updateRecord.Email);

            var _existRecord = await _repository.ExistAsync(_createdRecord.Id);
            Assert.True(_existRecord);

            var _selectedRecord = await _repository.SelectAsync(_createdRecord.Id);
            Assert.NotNull(_selectedRecord);
            Assert.Equal(_entity.Name, _selectedRecord.Name);
            Assert.Equal(_entity.Email, _selectedRecord.Email);

            var _selectedAllRecord = await _repository.SelectAllAsync();
            Assert.NotNull(_selectedAllRecord);
            Assert.True(_selectedAllRecord.Count() > 1);

            var _removeRecord = await _repository.DeleteAsync(_selectedRecord.Id);
            Assert.True(_removeRecord);

            var _userStandard = await _repository.FindByLogin("test@test.com");
            Assert.NotNull(_userStandard);
            Assert.Equal("test", _selectedRecord.Name);
            Assert.Equal("test@test.com", _selectedRecord.Email);
        }
    }
}