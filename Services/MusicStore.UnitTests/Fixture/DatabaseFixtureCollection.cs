using Xunit;

namespace Api.MusicStore.UnitTests
{
	[CollectionDefinition("MusicStore")]
	public class DatabaseFixtureCollection : ICollectionFixture<DatabaseFixture> { }
}
