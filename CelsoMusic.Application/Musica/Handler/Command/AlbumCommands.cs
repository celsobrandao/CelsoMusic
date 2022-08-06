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

    public class AtualizarAlbumCommand : IRequest<AtualizarAlbumCommandResponse>
    {
        public AlbumUpdateDTO Album { get; set; }

        public AtualizarAlbumCommand(AlbumUpdateDTO album)
        {
            Album = album;
        }
    }

    public class AtualizarAlbumCommandResponse
    {
        public AlbumOutputDTO Album { get; set; }

        public AtualizarAlbumCommandResponse(AlbumOutputDTO album)
        {
            Album = album;
        }
    }

    public class RemoverAlbumCommand : IRequest<RemoverAlbumCommandResponse>
    {
        public Guid ID { get; set; }

        public RemoverAlbumCommand(Guid id)
        {
            ID = id;
        }
    }

    public class RemoverAlbumCommandResponse
    {
        public RemoverAlbumCommandResponse()
        {
        }
    }
}
