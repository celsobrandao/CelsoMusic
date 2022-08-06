using CelsoMusic.Application.Usuario.DTO;

namespace CelsoMusic.Application.Usuario.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDTO> Criar(UsuarioInputDTO dto);
        Task<UsuarioOutputDTO> Atualizar(UsuarioUpdateDTO dto);
        Task Remover(Guid usuarioID);
        Task<UsuarioLoginOutputDTO> ValidarLogin(UsuarioLoginInputDTO dto);
        Task<List<UsuarioOutputDTO>> ObterTodos();
    }
}
