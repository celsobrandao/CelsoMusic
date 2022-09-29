using CelsoMusic.Application.Usuario.DTO;

namespace CelsoMusic.Application.Usuario.Service.Interfaces
{
    public interface IPlaylistService
    {
        Task<PlaylistOutputDTO> Criar(PlaylistInputDTO dto);
        Task<PlaylistOutputDTO> Atualizar(PlaylistUpdateDTO dto);
        Task Remover(Guid playlistID);
        Task<List<PlaylistOutputDTO>> ObterTodosPorUsuario(Guid usuarioID);
    }
}
