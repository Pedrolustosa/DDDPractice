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
        }
    }
}