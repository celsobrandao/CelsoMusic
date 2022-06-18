using CelsoMusic.Infra.Repository;

namespace CelsoMusic.Domain.Musica.Repository
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<Album> GetCompleto(Guid id);
    }
}
