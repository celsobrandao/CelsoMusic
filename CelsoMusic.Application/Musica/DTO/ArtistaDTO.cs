using System.ComponentModel.DataAnnotations;

namespace CelsoMusic.Application.Musica.DTO
{
    public record ArtistaInputDTO([Required(ErrorMessage = "O Nome deve ser informado.")] string Nome,
                                  [Required(ErrorMessage = "A Descrição deve ser informada.")] string Descricao,
                                  string Imagem);

    public record ArtistaUpdateDTO([Required(ErrorMessage = "O ID deve ser informado.")] Guid ID,
                                   [Required(ErrorMessage = "O Nome deve ser informado.")] string Nome,
                                   [Required(ErrorMessage = "A Descrição deve ser informada.")] string Descricao,
                                   string Imagem);

    public record ArtistaOutputDTO(Guid ID, string Nome, string Descricao, string Imagem, List<AlbumOutputDTO> Albuns);
}
