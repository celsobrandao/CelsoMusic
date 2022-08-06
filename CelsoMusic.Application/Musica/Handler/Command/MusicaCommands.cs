using CelsoMusic.Application.Musica.DTO;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler.Command
{
    public class CriarMusicaCommand : IRequest<CriarMusicaCommandResponse>
    {
        public MusicaInputDTO Musica { get; set; }
        public Guid AlbumID { get; set; }

        public CriarMusicaCommand(MusicaInputDTO musica,
                                 Guid albumID)
        {
            Musica = musica;
            AlbumID = albumID;
        }
    }

    public class CriarMusicaCommandResponse
    {
        public MusicaOutputDTO Musica { get; set; }

        public CriarMusicaCommandResponse(MusicaOutputDTO musica)
        {
            Musica = musica;
        }
    }

    public class AtualizarMusicaCommand : IRequest<AtualizarMusicaCommandResponse>
    {
        public MusicaUpdateDTO Musica { get; set; }

        public AtualizarMusicaCommand(MusicaUpdateDTO musica)
        {
            Musica = musica;
        }
    }

    public class AtualizarMusicaCommandResponse
    {
        public MusicaOutputDTO Musica { get; set; }

        public AtualizarMusicaCommandResponse(MusicaOutputDTO musica)
        {
            Musica = musica;
        }
    }

    public class RemoverMusicaCommand : IRequest<RemoverMusicaCommandResponse>
    {
        public Guid ID { get; set; }

        public RemoverMusicaCommand(Guid id)
        {
            ID = id;
        }
    }

    public class RemoverMusicaCommandResponse
    {
        public RemoverMusicaCommandResponse()
        {
        }
    }
}
