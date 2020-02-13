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
    public class SongsControllerUnitTests
    {
        readonly DatabaseFixture fixture;
        readonly Mock<ILogger<SongsController>> loggerMock;

        public SongsControllerUnitTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
            loggerMock = new Mock<ILogger<SongsController>>();
        }

        [Fact]
        public async Task Post_Song_CreatedInDatabase() 
        { 
            // Arrange
            var sngFake = GetSongFake();
            using var dbContext = new AppDbContext(fixture.DbContextOptions);

            // Act
            var sngController = new SongsController(dbContext, loggerMock.Object);
            var result = await sngController.Post(sngFake);

            // Assert
            Assert.IsType<ActionResult<Song>>(result); 
            Assert.NotNull(dbContext.Songs.Find(sngFake.Id));
        }

		[Fact]
		public async Task Put_Song_UpdatedInDatabase()
		{
			// Arrange
			var sngFake = GetSongFake();
			using var dbContext = new AppDbContext(fixture.DbContextOptions);
			dbContext.Add(sngFake);
			dbContext.SaveChanges();

			// Act
			var updatedName = "Updated-Field";
			sngFake.Name = updatedName;  
			var sngController = new SongsController(dbContext, loggerMock.Object);
			var result = await sngController.Put(sngFake.Id, sngFake) as NoContentResult;

			// Assert
			Assert.NotNull(result);  

            var entInDb = dbContext.Songs.AsNoTracking().FirstOrDefault(x => x.Id == sngFake.Id);
            Assert.Equal(updatedName, entInDb?.Name);  
		}

		[Fact]
		public async Task Delete_Song_DeletedInDatabase()
		{
			// Arrange
			var sngFake = GetSongFake();
			using var dbContext = new AppDbContext(fixture.DbContextOptions);
			dbContext.Add(sngFake);
			dbContext.SaveChanges();

			// Act
			var sngController = new SongsController(dbContext, loggerMock.Object);
			var result = await sngController.Delete(sngFake.Id);

			// Assert
			Assert.IsType<ActionResult<Song>>(result);  
			Assert.Null(dbContext.Songs.Find(sngFake.Id));  
		}

		private Song GetSongFake() 
        {
            return new Song
            {
                Name = "Test-Song",
                Brief = "Test-Brief",
                Description = "Test-Description",
                SongContent = "Test-Content"
            };
        }
    }
}
