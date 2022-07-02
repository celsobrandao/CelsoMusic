using CelsoMusic.Application.Musica.DTO;

namespace CelsoMusic.Application.Musica.Service.Interfaces
{
    public interface IArtistaService
    {
        Task<ArtistaOutputDTO> Criar(ArtistaInputDTO dto);
        Task<List<ArtistaOutputDTO>> ObterTodos();
    }
}
