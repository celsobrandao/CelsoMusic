using CelsoMusic.Domain.Musica;
using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace CelsoMusic.Repository.Repository.Musica
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(CelsoMusicContext context) : base(context)
        {
        }

        public Task<List<Album>> GetAllCompleto()
        {
            return DbSet.Include(x => x.Musicas)
                        .ToListAsync();
        }

        public Task<Album> GetCompleto(Guid id)
        {
            return DbSet.Include(x => x.Musicas)
                        .FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
