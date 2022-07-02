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
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<AlbumOutputDTO> Criar(AlbumInputDTO dto)
        {
            var album = _mapper.Map<Album>(dto);

            await _albumRepository.Save(album);

            return _mapper.Map<AlbumOutputDTO>(album);
        }

        public async Task<List<AlbumOutputDTO>> ObterTodos()
        {
            var result = await _albumRepository.GetAllCompleto();

            return _mapper.Map<List<AlbumOutputDTO>>(result);
        }
    }
}
