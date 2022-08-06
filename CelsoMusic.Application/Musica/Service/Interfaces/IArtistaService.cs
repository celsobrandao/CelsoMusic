using CelsoMusic.Application.Musica.DTO;

namespace CelsoMusic.Application.Musica.Service.Interfaces
{
    public interface IArtistaService
    {
        Task<ArtistaOutputDTO> Criar(ArtistaInputDTO dto);
        Task<ArtistaOutputDTO> Atualizar(ArtistaUpdateDTO dto);
        Task Remover(Guid artistaID);
        Task<List<ArtistaOutputDTO>> ObterTodos();
        Task<ArtistaOutputDTO> ObterPorID(Guid id);
    }
}
