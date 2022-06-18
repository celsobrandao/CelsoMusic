using CelsoMusic.Domain.Musica;
using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;

namespace CelsoMusic.Repository.Repository.Musica
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public GeneroRepository(CelsoMusicContext context) : base(context)
        {
        }
    }
}
