using CelsoMusic.Application.Musica.DTO;

namespace CelsoMusic.Application.Musica.Service.Interfaces
{
    public interface IAlbumService
    {
        Task<AlbumOutputDTO> Criar(AlbumInputDTO dto);
        Task<List<AlbumOutputDTO>> ObterTodos();
    }
}
