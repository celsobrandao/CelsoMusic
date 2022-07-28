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
}
