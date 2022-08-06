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

    public class AtualizarArtistaCommand : IRequest<AtualizarArtistaCommandResponse>
    {
        public ArtistaUpdateDTO Artista { get; set; }

        public AtualizarArtistaCommand(ArtistaUpdateDTO artista)
        {
            Artista = artista;
        }
    }

    public class AtualizarArtistaCommandResponse
    {
        public ArtistaOutputDTO Artista { get; set; }

        public AtualizarArtistaCommandResponse(ArtistaOutputDTO artista)
        {
            Artista = artista;
        }
    }

    public class RemoverArtistaCommand : IRequest<RemoverArtistaCommandResponse>
    {
        public Guid ID { get; set; }

        public RemoverArtistaCommand(Guid id)
        {
            ID = id;
        }
    }

    public class RemoverArtistaCommandResponse
    {
        public RemoverArtistaCommandResponse()
        {
        }
    }
}
