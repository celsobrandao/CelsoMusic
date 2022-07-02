using CelsoMusic.Application.Musica.DTO;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler.Command
{
    public class CriarAlbumCommand : IRequest<CriarAlbumCommandResponse>
    {
        public AlbumInputDTO Album { get; set; }
        public Guid ArtistaID { get; set; }

        public CriarAlbumCommand(AlbumInputDTO album,
                                 Guid artistaID)
        {
            Album = album;
            ArtistaID = artistaID;
        }
    }

    public class CriarAlbumCommandResponse
    {
        public AlbumOutputDTO Album { get; set; }

        public CriarAlbumCommandResponse(AlbumOutputDTO album)
        {
            Album = album;
        }
    }
}
