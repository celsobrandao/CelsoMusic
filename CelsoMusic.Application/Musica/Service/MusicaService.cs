using AutoMapper;
using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Service.Interfaces;
using CelsoMusic.Domain.Musica.Repository;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;

namespace CelsoMusic.Application.Musica.Service
{
    public class MusicaService : IMusicaService
    {
        private readonly IMusicaRepository _musicaRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public MusicaService(IMusicaRepository musicaRepository, IAlbumRepository albumRepository, IMapper mapper)
        {
            _musicaRepository = musicaRepository;
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<MusicaOutputDTO> Criar(MusicaInputDTO dto, Guid albumID)
        {
            var musica = _mapper.Map<MusicaModel>(dto);

            musica.Album = await _albumRepository.Get(albumID);

            await _musicaRepository.Save(musica);

            return _mapper.Map<MusicaOutputDTO>(musica);
        }

        public async Task<MusicaOutputDTO> Atualizar(MusicaUpdateDTO dto)
        {
            var musica = _mapper.Map<MusicaModel>(dto);

            await _musicaRepository.Update(musica);

            return _mapper.Map<MusicaOutputDTO>(musica);
        }

        public async Task Remover(Guid musicaID)
        {
            var musica = await _musicaRepository.Get(musicaID);

            await _musicaRepository.Delete(musica);
        }

        public async Task<List<MusicaOutputDTO>> ObterTodos()
        {
            var result = await _musicaRepository.GetAll();

            return _mapper.Map<List<MusicaOutputDTO>>(result);
        }

        public async Task<MusicaOutputDTO> ObterPorID(Guid id)
        {
            var result = await _musicaRepository.Get(id);

            return _mapper.Map<MusicaOutputDTO>(result);
        }
    }
}
