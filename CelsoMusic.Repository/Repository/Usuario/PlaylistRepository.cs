using CelsoMusic.Domain.Usuario;
using CelsoMusic.Domain.Usuario.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace CelsoMusic.Repository.Repository.Usuario
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(CelsoMusicContext context) : base(context)
        {
        }

        public Task<List<Playlist>> GetAllByUserID(Guid userID)
        {
            return DbSet.Include(x => x.Musicas)
                        .Where(x => x.Usuario.ID == userID)
                        .ToListAsync();
        }
    }
}
