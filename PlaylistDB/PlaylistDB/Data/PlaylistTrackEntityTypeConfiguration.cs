using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaylistDB;

public class PlaylistTrackEntityTypeConfiguration : IEntityTypeConfiguration<PlaylistTrack>
{
    public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
    {
        builder.HasKey(pt => new { pt.PlaylistId, pt.TrackId });
        //entity.HasNoKey();

        builder.ToTable("playlist_track", "music");

        builder.HasOne(d => d.Playlist)
            .WithMany(p => p.PlaylistTracks)
            .HasForeignKey(d => d.PlaylistId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_playlist_track_playlists");

        builder.HasOne(d => d.Track)
            .WithMany(t=> t.PlaylistTracks)
            .HasForeignKey(d => d.TrackId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_playlist_track_tracks");


    }
}