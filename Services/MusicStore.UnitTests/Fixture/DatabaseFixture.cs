using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.MusicStore.UnitTests
{
	public class DatabaseFixture : IDisposable
	{
		readonly SqliteConnection connection;

		public DatabaseFixture()
		{
			connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();

			using var context = new AppDbContext(DbContextOptions);
			context.Database.EnsureCreated();
		}

		public void Dispose()
		{
			connection.Close();
		}

		public DbContextOptions<AppDbContext> DbContextOptions => new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options;
	}
}
 