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
        public void AddShould_CallOnce_WhenObjectCorrect()
        {
            //Arrange
            var dbContextMock = new Mock<IDbContext>();
            var entityToAdd = new Session { Id = 1, SessionName = "Test Session 1", Date = new DateOnly(2024, 3, 2), Latitude = 12, Longitude = 22 };
            var dbSetMock = new Mock<DbSet<Session>>();
            dbContextMock.Setup(m => m.Set<Session>()).Returns(dbSetMock.Object);
            var repository = new Repository<Session>(dbContextMock.Object);

            //Act
            repository.Add(entityToAdd);

            //Assert
            dbSetMock.Verify(m => m.Add(entityToAdd), Times.Once);

        }
        [Fact]
        public void GetReturnsEntity_WhenEntityExists()
        {
            //Arrange
            var dbContextMock = new Mock<IDbContext>();
            var expectedEntity = new Session { Id = 1, SessionName = "Test Session 1", Date = new DateOnly(2024, 3, 2), Latitude = 12, Longitude = 22 };
            var entities = new List<Session> { expectedEntity }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Session>>();
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(entities.Provider);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(entities.Expression);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

            dbContextMock.Setup(m => m.Set<Session>()).Returns(dbSetMock.Object);

            var repository = new Repository<Session>(dbContextMock.Object);

            //Act
            var result = repository.Get(x => x.Id == expectedEntity.Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedEntity);
        }

        [Fact]
        public void GetReturnsNull_WhenEntityDoesNotExist()
        {
            //Arrange
            var dbContextMock = new Mock<IDbContext>();
            var expectedEntity = new Session { Id = 1, SessionName = "Test Session 1", Date = new DateOnly(2024, 3, 2), Latitude = 12, Longitude = 22 };
            var entities = new List<Session> { expectedEntity }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Session>>();
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(entities.Provider);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(entities.Expression);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

            dbContextMock.Setup(m => m.Set<Session>()).Returns(dbSetMock.Object);

            var repository = new Repository<Session>(dbContextMock.Object);

            //Act
            var result = repository.Get(x => x.Id == 66666);

            //Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetAllReturnsMultipleEntities_WhenEntitiesExist()
        {
            //Arrange
            var dbContextMock = new Mock<IDbContext>();
            var expectedEntityOne = new Session { Id = 1, SessionName = "Test Session 1", Date = new DateOnly(2024, 3, 2), Latitude = 12, Longitude = 22 };
            var expectedEntityTwo = new Session { Id = 2, SessionName = "Test Session 2", Date = new DateOnly(2023, 8, 23), Latitude = 21, Longitude = 2 };
            var expectedEntityThree = new Session { Id = 3, SessionName = "Test Session 3", Date = new DateOnly(2023, 6, 12), Latitude = 5, Longitude = 54 };
            var entities = new List<Session> { expectedEntityOne, expectedEntityTwo, expectedEntityThree }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Session>>();
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(entities.Provider);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(entities.Expression);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

            dbContextMock.Setup(m => m.Set<Session>()).Returns(dbSetMock.Object);

            var repository = new Repository<Session>(dbContextMock.Object);

            //Act
            var result = repository.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCountGreaterThan(1);
            result.Should().BeEquivalentTo(entities);
        }

        [Fact]
        public void GetAllReturnsNull_WhenEntitiesDontExist()
        {
            //Arrange
            var dbContextMock = new Mock<IDbContext>();
            var entities = new List<Session> {  }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Session>>();
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(entities.Provider);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(entities.Expression);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

            dbContextMock.Setup(m => m.Set<Session>()).Returns(dbSetMock.Object);

            var repository = new Repository<Session>(dbContextMock.Object);

            //Act
            var result = repository.GetAll();

            //Assert
            result.Should().BeNullOrEmpty();
        }

        [Fact]
        public void RemoveShouldDeleteEntity_WhenEntityExists()
        {
            //Arrange
            var dbContextMock = new Mock<IDbContext>();
            var expectedEntityOne = new Session { Id = 1, SessionName = "Test Session 1", Date = new DateOnly(2024, 3, 2), Latitude = 12, Longitude = 22 };
            var expectedEntityTwo = new Session { Id = 2, SessionName = "Test Session 2", Date = new DateOnly(2023, 8, 23), Latitude = 21, Longitude = 2 };
            var expectedEntityThree = new Session { Id = 3, SessionName = "Test Session 3", Date = new DateOnly(2023, 6, 12), Latitude = 5, Longitude = 54 };
            var entities = new List<Session> { expectedEntityOne, expectedEntityTwo, expectedEntityThree }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Session>>();
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(entities.Provider);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(entities.Expression);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

            dbSetMock.Setup(m => m.Remove(It.IsAny<Session>())).Callback<Session>((entity) => entities = entities.Where(e => e.Id != entity.Id).AsQueryable());
            dbContextMock.Setup(m => m.Set<Session>()).Returns(dbSetMock.Object);

            var repository = new Repository<Session>(dbContextMock.Object);

            //Act
            repository.Remove(expectedEntityOne);

            //Assert
            /*
            Ensure Set<Session>() was called once.
            Ensure Remove() was called once.
            Ensure Remove() was called with the correct object type.
             */
            dbContextMock.Verify(m => m.Set<Session>(), Times.Once);
            dbSetMock.Verify(m => m.Remove(It.IsAny<Session>()), Times.Once);
            dbSetMock.Verify(m => m.Remove(It.Is<Session>(e => e.Id == 1)), Times.Once);
        }

        [Fact]
        public void RemoveRangeShouldDeleteEntities_WhenEntitiesExist()
        {
            //Arrange
            var dbContextMock = new Mock<IDbContext>();
            var expectedEntityOne = new Session { Id = 1, SessionName = "Test Session 1", Date = new DateOnly(2024, 3, 2), Latitude = 12, Longitude = 22 };
            var expectedEntityTwo = new Session { Id = 2, SessionName = "Test Session 2", Date = new DateOnly(2023, 8, 23), Latitude = 21, Longitude = 2 };
            var expectedEntityThree = new Session { Id = 3, SessionName = "Test Session 3", Date = new DateOnly(2023, 6, 12), Latitude = 5, Longitude = 54 };
            var entities = new List<Session> { expectedEntityOne, expectedEntityTwo, expectedEntityThree }.AsQueryable();
            var entitiesToDelete = new List<Session> { expectedEntityOne, expectedEntityTwo }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Session>>();
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(entities.Provider);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(entities.Expression);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            dbSetMock.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

            dbSetMock.Setup(m => m.RemoveRange(It.IsAny<IEnumerable<Session>>())).Callback<IEnumerable<Session>>((entitiesToRemove) =>
            {
                entities = entities.Where(e => !entitiesToRemove.Contains(e)).AsQueryable();
            });

            dbContextMock.Setup(m => m.Set<Session>()).Returns(dbSetMock.Object);

            var repository = new Repository<Session>(dbContextMock.Object);

            //Act
            repository.RemoveRange(entitiesToDelete);

            //Assert
            dbContextMock.Verify(m => m.Set<Session>(), Times.Once);
            dbSetMock.Verify(m => m.RemoveRange(It.IsAny<IEnumerable<Session>>()), Times.Once);
            dbSetMock.Verify(m => m.RemoveRange(It.Is<IEnumerable<Session>>(e => e.Count() == 2)), Times.Once);
        }
    }
}
