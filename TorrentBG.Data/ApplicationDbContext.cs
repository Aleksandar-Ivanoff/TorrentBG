namespace TorrentBG.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TorrentBG.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        

        public DbSet<Torrent> Torrents { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Director> Directors { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public DbSet<TorrentUser> TorrentUser { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Torrent>().HasOne(x => x.Developer).WithMany(x => x.Torrents).HasForeignKey(c => c.DeveloperId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Torrent>().HasOne(x => x.Category).WithMany(x => x.Torrents).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Torrent>().HasOne(x => x.Genre).WithMany(x => x.Torrents).HasForeignKey(c => c.GenreId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Torrent>().HasOne(x => x.Director).WithMany(x => x.Torrents).HasForeignKey(c => c.DirectorId).OnDelete(DeleteBehavior.Restrict);


           
        
        }
    }
}
