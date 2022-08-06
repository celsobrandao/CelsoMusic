using AutoMapper;
using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Service;
using CelsoMusic.Domain.Musica;
using CelsoMusic.Domain.Musica.Repository;
using Moq;

namespace CelsoMusic.Test.Application.Musica
{
    public class ArtistaServiceTest
    {
        [Fact]
        public async Task DeveCriarArtistaComSucesso()
        {
            var dto = new ArtistaInputDTO("Banda ABC", "Banda de metal nórdico", "foto.jpg");
            var mockRepository = new Mock<IArtistaRepository>();
            var mockMapper = new Mock<IMapper>();

            var artista = new Artista()
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Imagem = dto.Imagem
            };

            var artistaDTO = new ArtistaOutputDTO(Guid.NewGuid(), artista.Nome, artista.Descricao, artista.Imagem, new List<AlbumOutputDTO>());

            mockMapper.Setup(x => x.Map<Artista>(dto)).Returns(artista);
            mockMapper.Setup(x => x.Map<ArtistaOutputDTO>(artista)).Returns(artistaDTO);

            mockRepository.Setup(x => x.Save(It.IsAny<Artista>())).Returns(Task.FromResult(artista));

            var service = new ArtistaService(mockRepository.Object, mockMapper.Object);

            var result = await service.Criar(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeveAtualizarArtistaComSucesso()
        {
            var dto = new ArtistaUpdateDTO(Guid.NewGuid(), "Banda ABC", "Banda de metal nórdico", "foto.jpg");
            var mockRepository = new Mock<IArtistaRepository>();
            var mockMapper = new Mock<IMapper>();

            var artista = new Artista()
            {
                ID = dto.ID,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Imagem = dto.Imagem
            };

            var artistaDTO = new ArtistaOutputDTO(artista.ID, artista.Nome, artista.Descricao, artista.Imagem, new List<AlbumOutputDTO>());

            mockMapper.Setup(x => x.Map<Artista>(dto)).Returns(artista);
            mockMapper.Setup(x => x.Map<ArtistaOutputDTO>(artista)).Returns(artistaDTO);

            mockRepository.Setup(x => x.Update(It.IsAny<Artista>())).Returns(Task.FromResult(artista));

            var service = new ArtistaService(mockRepository.Object, mockMapper.Object);

            var result = await service.Atualizar(dto);

            Assert.NotNull(result);
        }
    }
}
