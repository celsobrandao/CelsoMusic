using AutoMapper;
using CelsoMusic.Application.Playlist.DTO;
using CelsoMusic.Application.Playlist.Service.Interfaces;
using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Domain.Playlist.Repository;
using PlaylistModel = CelsoMusic.Domain.Playlist.Playlist;

namespace CelsoMusic.Application.Playlist.Service
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMusicaRepository _musicaRepository;
        private readonly IMapper _mapper;

        public PlaylistService(IPlaylistRepository playlistRepository, IMusicaRepository musicaRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _musicaRepository = musicaRepository;
            _mapper = mapper;
        }

        public async Task<PlaylistOutputDTO> Criar(PlaylistInputDTO dto)
        {
            var playlist = _mapper.Map<PlaylistModel>(dto);

            playlist.Musicas = new();
            foreach (var musicaID in dto.MusicaIDs)
            {
                playlist.Musicas.Add(await _musicaRepository.Get(musicaID));
            }

            await _playlistRepository.Save(playlist);

            return _mapper.Map<PlaylistOutputDTO>(playlist);
        }

        public async Task<PlaylistOutputDTO> Atualizar(PlaylistUpdateDTO dto)
        {
            var playlist = _mapper.Map<PlaylistModel>(dto);

            await _playlistRepository.Update(playlist);

            return _mapper.Map<PlaylistOutputDTO>(playlist);
        }

        public async Task Remover(Guid playlistID)
        {
            var playlist = await _playlistRepository.Get(playlistID);

            await _playlistRepository.Delete(playlist);
        }

        public async Task<List<PlaylistOutputDTO>> ObterTodosPorUsuario(Guid usuarioID)
        {
            var result = await _playlistRepository.GetAllByUserID(usuarioID);

            return _mapper.Map<List<PlaylistOutputDTO>>(result);
        }
    }
}
