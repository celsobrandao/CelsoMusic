using CelsoMusic.Infra.Repository;

namespace CelsoMusic.Domain.Musica.Repository
{
    public interface IArtistaRepository : IRepository<Artista>
    {
        Task<Artista> GetCompleto(Guid id);
    }
}
