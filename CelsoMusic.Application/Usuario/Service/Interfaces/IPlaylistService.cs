using CelsoMusic.Application.Usuario.DTO;

namespace CelsoMusic.Application.Usuario.Service.Interfaces
{
    public interface IPlaylistService
    {
        Task<PlaylistOutputDTO> Criar(PlaylistInputDTO dto, Guid usuarioID);
        Task<PlaylistOutputDTO> Atualizar(PlaylistInputDTO dto);
        Task Remover(Guid playlistID);
        Task<List<PlaylistOutputDTO>> ObterTodosPorUsuario(Guid usuarioID);
    }
}
