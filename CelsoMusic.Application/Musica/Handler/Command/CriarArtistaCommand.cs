using CelsoMusic.Application.Musica.DTO;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler.Command
{
    public class CriarArtistaCommand : IRequest<CriarArtistaCommandResponse>
    {
        public ArtistaInputDTO Artista { get; set; }

        public CriarArtistaCommand(ArtistaInputDTO artista)
        {
            Artista = artista;
        }
    }

    public class CriarArtistaCommandResponse
    {
        public ArtistaOutputDTO Artista { get; set; }

        public CriarArtistaCommandResponse(ArtistaOutputDTO artista)
        {
            Artista = artista;
        }
    }
}
