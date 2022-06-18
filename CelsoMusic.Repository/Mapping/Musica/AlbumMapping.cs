using CelsoMusic.Domain.Musica;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelsoMusic.Repository.Mapping.Musica
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albuns");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.DataLancamento)
                .IsRequired();

            builder.Property(x => x.Descricao);

            builder.Property(x => x.Imagem);

            builder.HasMany(x => x.Musicas)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
