using CelsoMusic.Application.Playlist.DTO;

namespace CelsoMusic.Application.Playlist.Service.Interfaces
{
    public interface IPlaylistService
    {
        Task<PlaylistOutputDTO> Criar(PlaylistInputDTO dto);
        Task<PlaylistOutputDTO> Atualizar(PlaylistUpdateDTO dto);
        Task Remover(Guid playlistID);
        Task<List<PlaylistOutputDTO>> ObterTodosPorUsuario(Guid usuarioID);
    }
}
