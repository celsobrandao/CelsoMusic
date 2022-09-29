using CelsoMusic.Application.Playlist.DTO;
using PlaylistModel = CelsoMusic.Domain.Playlist.Playlist;

namespace CelsoMusic.Application.Playlist.Profile
{
    public class PlaylistProfile : AutoMapper.Profile
    {
        public PlaylistProfile()
        {
            CreateMap<PlaylistModel, PlaylistOutputDTO>();

            CreateMap<PlaylistInputDTO, PlaylistModel>();

            CreateMap<PlaylistUpdateDTO, PlaylistModel>();
        }
    }
}
