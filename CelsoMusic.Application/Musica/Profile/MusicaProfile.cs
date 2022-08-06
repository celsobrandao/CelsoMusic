using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Domain.Musica;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;

namespace CelsoMusic.Application.Musica.Profile
{
    public class MusicaProfile : AutoMapper.Profile
    {
        public MusicaProfile()
        {
            CreateMap<MusicaModel, MusicaOutputDTO>()
                .ForMember(x => x.Duracao, f => f.MapFrom(m => m.Duracao.Formatada));

            CreateMap<MusicaInputDTO, MusicaModel>()
                .ForPath(x => x.Duracao.Valor, f => f.MapFrom(m => m.Duracao));

            CreateMap<MusicaUpdateDTO, MusicaModel>()
                .ForPath(x => x.Duracao.Valor, f => f.MapFrom(m => m.Duracao));

            CreateMap<Album, AlbumOutputDTO>();

            CreateMap<AlbumInputDTO, Album>();

            CreateMap<AlbumUpdateDTO, Album>();

            CreateMap<Artista, ArtistaOutputDTO>();

            CreateMap<ArtistaInputDTO, Artista>();

            CreateMap<ArtistaUpdateDTO, Artista>();
        }
    }
}
