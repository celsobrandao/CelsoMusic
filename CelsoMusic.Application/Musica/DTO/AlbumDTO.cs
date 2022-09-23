namespace CelsoMusic.Application.Musica.DTO
{
    public record AlbumInputDTO(string Nome, DateTime DataLancamento, string Descricao, string ImagemUrl, List<MusicaInputDTO> Musicas);

    public record AlbumUpdateDTO(Guid ID, string Nome, DateTime DataLancamento, string Descricao, string ImagemUrl, List<MusicaInputDTO> Musicas);

    public record AlbumOutputDTO(Guid ID, string Nome, DateTime DataLancamento, string Descricao, string Imagem, List<MusicaOutputDTO> Musicas);
}
