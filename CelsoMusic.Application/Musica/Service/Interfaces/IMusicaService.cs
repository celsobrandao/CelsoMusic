using CelsoMusic.Application.Musica.DTO;

namespace CelsoMusic.Application.Musica.Service.Interfaces
{
    public interface IMusicaService
    {
        Task<MusicaOutputDTO> Criar(MusicaInputDTO dto, Guid albumID);
        Task<MusicaOutputDTO> Atualizar(MusicaUpdateDTO dto);
        Task Remover(Guid musicaID);
        Task<List<MusicaOutputDTO>> ObterTodos();
        Task<MusicaOutputDTO> ObterPorID(Guid id);
    }
}
