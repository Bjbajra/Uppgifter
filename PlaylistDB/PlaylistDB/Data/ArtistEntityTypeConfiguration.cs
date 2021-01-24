using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaylistDB;

public class ArtistEntityTypeConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("artists", "music");

        builder.Property(e => e.ArtistId).ValueGeneratedNever();

        builder.Property(e => e.Name).HasMaxLength(120);
    }
}