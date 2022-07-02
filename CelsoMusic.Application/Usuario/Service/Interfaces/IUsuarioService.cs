using CelsoMusic.Application.Usuario.DTO;

namespace CelsoMusic.Application.Usuario.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDTO> Criar(UsuarioInputDTO dto);
        Task<UsuarioLoginOutputDTO> ValidarLogin(UsuarioLoginInputDTO dto);
        Task<List<UsuarioOutputDTO>> ObterTodos();
    }
}
