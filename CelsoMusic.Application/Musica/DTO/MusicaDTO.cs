namespace CelsoMusic.Application.Musica.DTO
{
    public record MusicaInputDTO(string Nome, string Descricao, string Duracao);

    public record MusicaOutputDTO(Guid ID, string Nome, string Descricao, string Duracao);
}
