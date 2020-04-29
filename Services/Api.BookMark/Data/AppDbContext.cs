using Data.BookMark;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BookMark
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AlbumBookMark> AlbumBookMarks { get; set; }
        public DbSet<SongBookMark> SongBookMarks { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //optionsBuilder.UseSqlite("DataSource=bookmark.db");
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=arcoda-bookmarks;Integrated Security=True;", b => b.MigrationsAssembly("Api.BookMark"));
            // optionsBuilder.UseNpgsql("Host=pg;Database=arcoda-bookmark;Username=postgres;Password=pgadmin;port=5433", b => b.MigrationsAssembly("Api.BookMark"));
            optionsBuilder.UseNpgsql("Host=pg;Database=arcoda-bookmark;Username=postgresadmin;Password=admin123;", b => b.MigrationsAssembly("Api.BookMark"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
