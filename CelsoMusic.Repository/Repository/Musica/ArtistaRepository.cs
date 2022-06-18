using CelsoMusic.Domain.Musica;
using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace CelsoMusic.Repository.Repository.Musica
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public ArtistaRepository(CelsoMusicContext context) : base(context)
        {
        }

        public Task<Artista> GetCompleto(Guid id)
        {
            return DbSet.Include(x => x.Albuns)
                            .ThenInclude(x => x.Musicas)
                                .ThenInclude(x => x.Generos)
                        .FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
