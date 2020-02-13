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
    public class AlbumsControllerUnitTests
    {
        readonly DatabaseFixture fixture;
        readonly Mock<ILogger<AlbumsController>> loggerMock;

        public AlbumsControllerUnitTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
            loggerMock = new Mock<ILogger<AlbumsController>>();
        }

        [Fact]
        public async Task Post_Album_CreatedInDatabase() 
        { 
            // Arrange
            var sngFake = GetAlbumFake();
            using var dbContext = new AppDbContext(fixture.DbContextOptions);

            // Act
            var sngController = new AlbumsController(dbContext, loggerMock.Object);
            var result = await sngController.Post(sngFake);

            // Assert
            Assert.IsType<ActionResult<Album>>(result); 
            Assert.NotNull(dbContext.Albums.Find(sngFake.Id));
        }

		[Fact]
		public async Task Put_Album_UpdatedInDatabase()
		{
			// Arrange
			var sngFake = GetAlbumFake();
			using var dbContext = new AppDbContext(fixture.DbContextOptions);
			dbContext.Add(sngFake);
			dbContext.SaveChanges();

			// Act
			var updatedName = "Updated-Field";
			sngFake.Brief = updatedName; 
			var sngController = new AlbumsController(dbContext, loggerMock.Object);
			var result = await sngController.Put(sngFake.Id, sngFake) as NoContentResult;

			// Assert
			Assert.NotNull(result);  

            var entInDb = dbContext.Albums.AsNoTracking().FirstOrDefault(x => x.Id == sngFake.Id);
            Assert.Equal(updatedName, entInDb?.Brief); 
		}

		[Fact]
		public async Task Delete_Album_DeletedInDatabase()
		{
			// Arrange
			var sngFake = GetAlbumFake();
			using var dbContext = new AppDbContext(fixture.DbContextOptions);
			dbContext.Add(sngFake);
			dbContext.SaveChanges();

			// Act
			var sngController = new AlbumsController(dbContext, loggerMock.Object);
			var result = await sngController.Delete(sngFake.Id);

			// Assert
			Assert.IsType<ActionResult<Album>>(result);  
			Assert.Null(dbContext.Albums.Find(sngFake.Id));  
		}

		private Album GetAlbumFake() 
        {
            return new Album
            { 
                Brief = "Test-Brief", 
            };
        }
    }
}
