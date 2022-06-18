using CelsoMusic.Domain.Usuario;
using CelsoMusic.Domain.Usuario.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;

namespace CelsoMusic.Repository.Repository.Usuario
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(CelsoMusicContext context) : base(context)
        {
        }
    }
}
