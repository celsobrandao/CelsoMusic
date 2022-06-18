using CelsoMusic.Domain.Usuario.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using UsuarioModel = CelsoMusic.Domain.Usuario.Usuario;

namespace CelsoMusic.Repository.Repository.Usuario
{
    public class UsuarioRepository : Repository<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(CelsoMusicContext context) : base(context)
        {
        }
    }
}
