using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaylistModel = CelsoMusic.Domain.Playlist.Playlist;

namespace CelsoMusic.Repository.Mapping.Playlist
{
    public class PlaylistMapping : IEntityTypeConfiguration<PlaylistModel>
    {
        public void Configure(EntityTypeBuilder<PlaylistModel> builder)
        {
            builder.ToTable("Playlists");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UsuarioID)
                .IsRequired();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Descricao);

            builder.HasMany(x => x.Musicas)
                .WithMany(x => x.Playlists);
        }
    }
}
