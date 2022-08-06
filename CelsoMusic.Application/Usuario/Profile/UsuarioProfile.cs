using CelsoMusic.Application.Usuario.DTO;
using CelsoMusic.Domain.Usuario;
using UsuarioModel = CelsoMusic.Domain.Usuario.Usuario;

namespace CelsoMusic.Application.Usuario.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioModel, UsuarioOutputDTO>()
                .ForMember(x => x.Email, f => f.MapFrom(m => m.Email.Valor));

            CreateMap<UsuarioInputDTO, UsuarioModel>()
                .ForPath(x => x.Email.Valor, f => f.MapFrom(m => m.Email));

            CreateMap<UsuarioUpdateDTO, UsuarioModel>()
                .ForPath(x => x.Email.Valor, f => f.MapFrom(m => m.Email));

            CreateMap<Playlist, PlaylistOutputDTO>();

            CreateMap<PlaylistInputDTO, Playlist>();

            CreateMap<PlaylistUpdateDTO, Playlist>();
        }
    }
}
