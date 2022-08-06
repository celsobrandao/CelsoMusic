using CelsoMusic.Application.Musica.DTO;
using MediatR;

namespace CelsoMusic.Application.Musica.Handler.Query
{
    public class GetAllMusicaQuery : IRequest<GetAllMusicaQueryResponse>
    {
    }

    public class GetAllMusicaQueryResponse
    {
        public IList<MusicaOutputDTO> Musicas { get; set; }

        public GetAllMusicaQueryResponse(IList<MusicaOutputDTO> musicas)
        {
            Musicas = musicas;
        }
    }

    public class GetMusicaQuery : IRequest<GetMusicaQueryResponse>
    {
        public Guid MusicaID { get; set; }

        public GetMusicaQuery(Guid musicaID)
        {
            MusicaID = musicaID;
        }
    }

    public class GetMusicaQueryResponse
    {
        public MusicaOutputDTO Musica { get; set; }

        public GetMusicaQueryResponse(MusicaOutputDTO musica)
        {
            Musica = musica;
        }
    }
}
