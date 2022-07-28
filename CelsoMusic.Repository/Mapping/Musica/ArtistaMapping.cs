using CelsoMusic.Domain.Musica;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelsoMusic.Repository.Mapping.Musica
{
    public class ArtistaMapping : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("Artistas");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Descricao);

            builder.Property(x => x.Imagem);

            builder.HasMany(x => x.Albuns)
                .WithOne(x => x.Artista)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
