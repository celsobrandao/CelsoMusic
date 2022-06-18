using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;

namespace CelsoMusic.Repository.Repository.Musica
{
    public class MusicaRepository : Repository<MusicaModel>, IMusicaRepository
    {
        public MusicaRepository(CelsoMusicContext context) : base(context)
        {
        }
    }
}
