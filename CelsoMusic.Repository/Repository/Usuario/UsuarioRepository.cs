using CelsoMusic.Domain.Usuario.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using Microsoft.EntityFrameworkCore;
using UsuarioModel = CelsoMusic.Domain.Usuario.Usuario;

namespace CelsoMusic.Repository.Repository.Usuario
{
    public class UsuarioRepository : Repository<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(CelsoMusicContext context) : base(context)
        {
        }

        public Task<Guid> ValidarLogin(string email, string senha)
        {
            return DbSet.Where(x => x.Email.Valor.ToUpper() == email.ToUpper() && x.Senha.Valor == senha)
                        .Select(x => x.ID)
                        .FirstOrDefaultAsync();
        }
    }
}
