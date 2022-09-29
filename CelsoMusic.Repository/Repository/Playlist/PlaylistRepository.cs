using CelsoMusic.Domain.Playlist.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using Microsoft.EntityFrameworkCore;
using PlaylistModel = CelsoMusic.Domain.Playlist.Playlist;

namespace CelsoMusic.Repository.Repository.Playlist
{
    public class PlaylistRepository : Repository<PlaylistModel>, IPlaylistRepository
    {
        public PlaylistRepository(CelsoMusicContext context) : base(context)
        {
        }

        public Task<List<PlaylistModel>> GetAllByUserID(Guid userID)
        {
            return DbSet.Include(x => x.Musicas)
                        .Where(x => x.UsuarioID == userID)
                        .ToListAsync();
        }
    }
}
