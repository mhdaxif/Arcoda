using Api.MusicStore;
using Api.MusicStore.Controllers;
using Api.MusicStore.UnitTests;
using Data.MusicStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MusicStore.UnitTests.ControllerTests
{
    [Collection("MusicStore")]
    public class ArtistsControllerUnitTests
    {
        readonly DatabaseFixture fixture;
        readonly Mock<ILogger<ArtistsController>> loggerMock;
     
        public ArtistsControllerUnitTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
            loggerMock = new Mock<ILogger<ArtistsController>>();
        }
         
        [Fact]
        public async Task Post_Artist_CreatedInDatabase()
        {
            // Arrange
            var artstFake = GetArtistFake();
            using var dbContext = new AppDbContext(fixture.DbContextOptions);

            // Act
            var artstcontroller = new ArtistsController(dbContext, loggerMock.Object);
            var result = await artstcontroller.Post(artstFake);

            // Assert
            Assert.IsType<ActionResult<Artist>>(result);
            Assert.NotNull(dbContext.Artists.Find(artstFake.Id));
        }

        [Fact]
        public async Task Put_Artist_UpdatedInDatabase()
        {
            // Arrange
            var artstFake = GetArtistFake();
            using var dbContext = new AppDbContext(fixture.DbContextOptions);
            dbContext.Add(artstFake);
            dbContext.SaveChanges();

            // Act
            var updatedName = "Updated-Field";
            artstFake.Name = updatedName;  
            var artstcontroller = new ArtistsController(dbContext, loggerMock.Object);
            var result = await artstcontroller.Put(artstFake.Id, artstFake) as NoContentResult;

            // Assert
            Assert.NotNull(result); 

            var entInDb = dbContext.Artists.AsNoTracking().FirstOrDefault(x => x.Id == artstFake.Id);
            Assert.Equal(updatedName, entInDb?.Name);  
        }

        [Fact]
        public async Task Delete_Artist_DeletedInDatabase()
        {
            // Arrange
            var artstFake = GetArtistFake();
            using var dbContext = new AppDbContext(fixture.DbContextOptions);
            dbContext.Add(artstFake);
            dbContext.SaveChanges();

            // Act
            var artstcontroller = new ArtistsController(dbContext, loggerMock.Object);
            var result = await artstcontroller.Delete(artstFake.Id);

            // Assert
            Assert.IsType<ActionResult<Artist>>(result);
            Assert.Null(dbContext.Artists.Find(artstFake.Id));
        }

        private Artist GetArtistFake()
        {
            return new Artist
            {
                Name = "Test-Name-Artist",
            };
        }
    }
}
