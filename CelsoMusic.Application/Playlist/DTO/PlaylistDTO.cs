using CelsoMusic.Application.Musica.DTO;
using System.ComponentModel.DataAnnotations;

namespace CelsoMusic.Application.Playlist.DTO
{
    public record PlaylistInputDTO([Required(ErrorMessage = "O ID do Usuário deve ser informado.")] Guid UsuarioID,
                                   [Required(ErrorMessage = "O Nome deve ser informado.")] string Nome,
                                   string Descricao,
                                   List<Guid> MusicaIDs);

    public record PlaylistUpdateDTO([Required(ErrorMessage = "O ID deve ser informado.")] Guid ID,
                                    [Required(ErrorMessage = "O Nome deve ser informado.")] string Nome,
                                    string Descricao,
                                    List<Guid> MusicaIDs);

    public record PlaylistOutputDTO(Guid ID, string Nome, string Descricao, List<MusicaOutputDTO> Musicas);
}
