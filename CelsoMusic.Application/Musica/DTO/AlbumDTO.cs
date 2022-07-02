namespace CelsoMusic.Application.Musica.DTO
{
    public record AlbumInputDTO(string Nome, DateTime DataLancamento, string Descricao, string Imagem, List<MusicaInputDTO> Musicas);

    public record AlbumOutputDTO(Guid ID, string Nome, DateTime DataLancamento, string Descricao, string Imagem, List<MusicaOutputDTO> Musicas);
}
