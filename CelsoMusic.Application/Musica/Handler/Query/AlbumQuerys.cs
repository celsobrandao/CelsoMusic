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

    public class GetAlbumQuery : IRequest<GetAlbumQueryResponse>
    {
        public Guid AlbumID { get; set; }

        public GetAlbumQuery(Guid albumID)
        {
            AlbumID = albumID;
        }
    }

    public class GetAlbumQueryResponse
    {
        public AlbumOutputDTO Album { get; set; }

        public GetAlbumQueryResponse(AlbumOutputDTO album)
        {
            Album = album;
        }
    }
}
