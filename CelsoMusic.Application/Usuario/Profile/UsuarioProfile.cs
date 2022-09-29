using CelsoMusic.Application.Usuario.DTO;
using CelsoMusic.Domain.Usuario;

namespace CelsoMusic.Application.Usuario.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Playlist, PlaylistOutputDTO>();

            CreateMap<PlaylistInputDTO, Playlist>();

            CreateMap<PlaylistUpdateDTO, Playlist>();
        }
    }
}
