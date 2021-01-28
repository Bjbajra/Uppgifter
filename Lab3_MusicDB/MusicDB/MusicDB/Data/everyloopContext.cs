using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace MusicDB
{
    public partial class everyloopContext : DbContext
    {
        public everyloopContext()
        {
        }

        public everyloopContext(DbContextOptions<everyloopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer($"{config.GetConnectionString("conString")}");

                //optionsBuilder.UseSqlServer("Server=DESKTOP-9H83LJ6;Database=everyloop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaylistTrack>().HasKey(pt => new { pt.PlaylistId, pt.TrackId });
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            new AlbumEntityTypeConfiguration().Configure(modelBuilder.Entity<Album>());
            new ArtistEntityTypeConfiguration().Configure(modelBuilder.Entity<Artist>());
            new PlaylistEntityTypeConfiguration().Configure(modelBuilder.Entity<Playlist>());
            new PlaylistTrackEntityTypeConfiguration().Configure(modelBuilder.Entity<PlaylistTrack>());
            new TrackEntityTypeConfiguration().Configure(modelBuilder.Entity<Track>());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
