using AutoMapper;
using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Service.Interfaces;
using CelsoMusic.Domain.Musica;
using CelsoMusic.Domain.Musica.Repository;

namespace CelsoMusic.Application.Musica.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IArtistaRepository artistaRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _artistaRepository = artistaRepository;
            _mapper = mapper;
        }

        public async Task<AlbumOutputDTO> Criar(AlbumInputDTO dto, Guid artistaID)
        {
            var album = _mapper.Map<Album>(dto);

            album.Artista = await _artistaRepository.Get(artistaID);

            await _albumRepository.Save(album);

            return _mapper.Map<AlbumOutputDTO>(album);
        }

        public async Task<AlbumOutputDTO> Atualizar(AlbumUpdateDTO dto)
        {
            var album = _mapper.Map<Album>(dto);

            await _albumRepository.Update(album);

            return _mapper.Map<AlbumOutputDTO>(album);
        }

        public async Task Remover(Guid albumID)
        {
            var album = await _albumRepository.Get(albumID);

            await _albumRepository.Delete(album);
        }

        public async Task<List<AlbumOutputDTO>> ObterTodos()
        {
            var result = await _albumRepository.GetAllCompleto();

            return _mapper.Map<List<AlbumOutputDTO>>(result);
        }

        public async Task<AlbumOutputDTO> ObterPorID(Guid id)
        {
            var result = await _albumRepository.GetCompleto(id);

            return _mapper.Map<AlbumOutputDTO>(result);
        }
    }
}
