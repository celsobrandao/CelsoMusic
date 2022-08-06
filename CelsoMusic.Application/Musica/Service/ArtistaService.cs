using AutoMapper;
using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Service.Interfaces;
using CelsoMusic.Domain.Musica;
using CelsoMusic.Domain.Musica.Repository;

namespace CelsoMusic.Application.Musica.Service
{
    public class ArtistaService : IArtistaService
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;

        public ArtistaService(IArtistaRepository artistaRepository,
                              IMapper mapper)
        {
            _artistaRepository = artistaRepository;
            _mapper = mapper;
        }

        public async Task<ArtistaOutputDTO> Criar(ArtistaInputDTO dto)
        {
            var artista = _mapper.Map<Artista>(dto);

            await _artistaRepository.Save(artista);

            return _mapper.Map<ArtistaOutputDTO>(artista);
        }

        public async Task<ArtistaOutputDTO> Atualizar(ArtistaUpdateDTO dto)
        {
            var artista = _mapper.Map<Artista>(dto);

            await _artistaRepository.Update(artista);

            return _mapper.Map<ArtistaOutputDTO>(artista);
        }

        public async Task Remover(Guid artistaID)
        {
            var artista = await _artistaRepository.Get(artistaID);

            await _artistaRepository.Delete(artista);
        }

        public async Task<List<ArtistaOutputDTO>> ObterTodos()
        {
            var result = await _artistaRepository.GetAll();

            return _mapper.Map<List<ArtistaOutputDTO>>(result);
        }

        public async Task<ArtistaOutputDTO> ObterPorID(Guid id)
        {
            var result = await _artistaRepository.GetCompleto(id);

            return _mapper.Map<ArtistaOutputDTO>(result);
        }
    }
}
