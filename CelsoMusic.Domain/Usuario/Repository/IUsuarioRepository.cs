using CelsoMusic.Infra.Repository;

namespace CelsoMusic.Domain.Usuario.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Guid> ValidarLogin(string email, string senha);
    }
}
