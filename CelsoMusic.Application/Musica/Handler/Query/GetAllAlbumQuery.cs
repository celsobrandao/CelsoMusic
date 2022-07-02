using CelsoMusic.Application.Musica.DTO;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler.Query
{
    public class GetAllAlbumQuery : IRequest<GetAllAlbumQueryResponse>
    {
    }

    public class GetAllAlbumQueryResponse
    {
        public IList<AlbumOutputDTO> Albuns { get; set; }

        public GetAllAlbumQueryResponse(IList<AlbumOutputDTO> albuns)
        {
            Albuns = albuns;
        }
    }
}
