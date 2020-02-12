using Data.MusicStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.MusicStore.Data
{
    public static class Seed
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if(context.Albums.Any() == false)
                {
                    var albums = MockDataProvider.GetAlbums();

                    await context.Albums.AddRangeAsync(albums);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
