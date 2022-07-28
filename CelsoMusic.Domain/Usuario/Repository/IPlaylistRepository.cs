using CelsoMusic.Infra.Repository;

namespace CelsoMusic.Domain.Usuario.Repository
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<List<Playlist>> GetAllByUserID(Guid userID);
    }
}
