using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;

namespace CelsoMusic.Repository.Mapping.Musica
{
    public class MusicaMapping : IEntityTypeConfiguration<MusicaModel>
    {
        public void Configure(EntityTypeBuilder<MusicaModel> builder)
        {
            builder.ToTable("Musicas");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Descricao);

            builder.OwnsOne(x => x.Duracao, p =>
            {
                p.Property(f => f.Valor)
                    .HasColumnName("Duracao")
                    .IsRequired();
            });

            builder.Property(x => x.Audio);

            builder.HasMany(x => x.Generos)
                .WithMany(x => x.Musicas);
        }
    }
}
