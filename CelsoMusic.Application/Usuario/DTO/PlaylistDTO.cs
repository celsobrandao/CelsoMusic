using CelsoMusic.Application.Musica.DTO;
using System.ComponentModel.DataAnnotations;

namespace CelsoMusic.Application.Usuario.DTO
{
    public record PlaylistInputDTO([Required(ErrorMessage = "O Nome deve ser informado.")] string Nome,
                                   string Descricao,
                                   List<Guid> MusicaIDs);

    public record PlaylistOutputDTO(Guid ID, string Nome, string Descricao, List<MusicaOutputDTO> Musicas);
}
