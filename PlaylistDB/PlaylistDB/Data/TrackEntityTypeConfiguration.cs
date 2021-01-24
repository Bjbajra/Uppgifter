using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaylistDB;

public class TrackEntityTypeConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.ToTable("tracks", "music");

        builder.Property(e => e.TrackId).ValueGeneratedNever();

        builder.Property(e => e.Composer).HasMaxLength(220);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(d => d.Album)
            .WithMany(p => p.Tracks)
            .HasForeignKey(d => d.AlbumId)
            .HasConstraintName("FK_tracks_albums");

    }
}