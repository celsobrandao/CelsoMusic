using CelsoMusic.Application.Musica.DTO;

namespace CelsoMusic.Application.Musica.Service.Interfaces
{
    public interface IAlbumService
    {
        Task<AlbumOutputDTO> Criar(AlbumInputDTO dto, Guid artistaID);
        Task<AlbumOutputDTO> Atualizar(AlbumUpdateDTO dto);
        Task Remover(Guid albumID);
        Task<List<AlbumOutputDTO>> ObterTodos();
        Task<AlbumOutputDTO> ObterPorID(Guid id);
    }
}
