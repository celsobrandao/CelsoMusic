using AutoMapper;
using CelsoMusic.Application.Usuario.Service.Interfaces;
using CelsoMusic.Domain.Usuario.Repository;

namespace CelsoMusic.Application.Usuario.Service
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }
    }
}
