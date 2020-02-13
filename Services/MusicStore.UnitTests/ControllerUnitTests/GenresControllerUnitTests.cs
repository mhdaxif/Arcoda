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
    public class GenresControllerUnitTests
    {
        readonly DatabaseFixture fixture;
        readonly Mock<ILogger<GenresController>> loggerMock;

        public GenresControllerUnitTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
            loggerMock = new Mock<ILogger<GenresController>>();
        }

        [Fact]
        public async Task Post_Genre_CreatedInDatabase() 
        { 
            // Arrange
            var gnreFake = GetGenreFake();
            using var dbContext = new AppDbContext(fixture.DbContextOptions);

            // Act
            var gnreController = new GenresController(dbContext, loggerMock.Object);
            var result = await gnreController.Post(gnreFake);

            // Assert
            Assert.IsType<ActionResult<Genre>>(result); 
            Assert.NotNull(dbContext.Genres.Find(gnreFake.Id));
        }

		[Fact]
		public async Task Put_Genre_UpdatedInDatabase()
		{
			// Arrange
			var gnreFake = GetGenreFake();
			using var dbContext = new AppDbContext(fixture.DbContextOptions);
			dbContext.Add(gnreFake);
			dbContext.SaveChanges();

			// Act
			var updatedName = "Updated-Field";
			gnreFake.Name = updatedName;  
			var gnreController = new GenresController(dbContext, loggerMock.Object);
			var result = await gnreController.Put(gnreFake.Id, gnreFake) as NoContentResult;

			// Assert
			Assert.NotNull(result);  

            var entInDb = dbContext.Genres.AsNoTracking().FirstOrDefault(x => x.Id == gnreFake.Id);
            Assert.Equal(updatedName, entInDb?.Name);  
		}

		[Fact]
		public async Task Delete_Genre_DeletedInDatabase()
		{
			// Arrange
			var gnreFake = GetGenreFake();
			using var dbContext = new AppDbContext(fixture.DbContextOptions);
			dbContext.Add(gnreFake);
			dbContext.SaveChanges();

			// Act
			var gnreController = new GenresController(dbContext, loggerMock.Object);
			var result = await gnreController.Delete(gnreFake.Id);

			// Assert
			Assert.IsType<ActionResult<Genre>>(result);  
			Assert.Null(dbContext.Genres.Find(gnreFake.Id));  
		}

		private Genre GetGenreFake() 
        {
            return new Genre
            {
                Name = "Test-Genre", 
                Description = "Test-Description", 
            };
        }
    }
}
