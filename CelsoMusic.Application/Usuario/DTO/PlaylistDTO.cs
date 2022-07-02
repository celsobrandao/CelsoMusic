using System.ComponentModel.DataAnnotations;

namespace CelsoMusic.Application.Usuario.DTO
{
    public record PlaylistInputDTO([Required(ErrorMessage = "O Nome deve ser informado.")] string Nome,
                                   string Descricao);

    public record PlaylistOutputDTO(Guid ID, string Nome, string Descricao);
}
