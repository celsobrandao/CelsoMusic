using CelsoMusic.Infra.Repository;

namespace CelsoMusic.Domain.Playlist.Repository
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<List<Playlist>> GetAllByUserID(Guid userID);
    }
}
