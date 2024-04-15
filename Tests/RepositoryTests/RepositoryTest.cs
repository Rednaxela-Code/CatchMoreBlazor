using DataAccess.Data;
using DataAccess.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;

namespace Tests.RepositoryTests
{
    public class RepositoryTest
    {
        [Fact]
        public void GetReturnsEntity_WhenEntityExists()
        {
            //Arrange
            var dbContext = new Mock<IDbContext>();
            var expectedEntity = new Session { Id = 1, SessionName = "Test Session 1", Date = new DateOnly(2024, 3, 2), Latitude = 12, Longitude = 22 };
            var entities = new List<Session> { expectedEntity }.AsQueryable();

            var dbSet = new Mock<DbSet<Session>>();
            dbSet.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(entities.Provider);
            dbSet.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(entities.Expression);
            dbSet.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            dbSet.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

            dbContext.Setup(m => m.Sessions).Returns(dbSet.Object);

            var repository = new Repository<Session>(dbContext.Object);

            //Act
            var result = repository.Get(x => x.Id == expectedEntity.Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedEntity);
        }
    }
}
