using CelsoMusic.Application.Musica.DTO;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler.Query
{
    public class GetAllArtistaQuery : IRequest<GetAllArtistaQueryResponse>
    {
    }

    public class GetAllArtistaQueryResponse
    {
        public IList<ArtistaOutputDTO> Artistas { get; set; }

        public GetAllArtistaQueryResponse(IList<ArtistaOutputDTO> artistas)
        {
            Artistas = artistas;
        }
    }

    public class GetArtistaQuery : IRequest<GetArtistaQueryResponse>
    {
        public Guid ArtistaID { get; set; }

        public GetArtistaQuery(Guid artistaID)
        {
            ArtistaID = artistaID;
        }
    }

    public class GetArtistaQueryResponse
    {
        public ArtistaOutputDTO Artista { get; set; }

        public GetArtistaQueryResponse(ArtistaOutputDTO artista)
        {
            Artista = artista;
        }
    }
}
