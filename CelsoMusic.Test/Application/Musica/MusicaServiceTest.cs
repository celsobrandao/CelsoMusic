using AutoMapper;
using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Musica.Service;
using CelsoMusic.Domain.Musica;
using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Domain.Musica.ValueObject;
using Moq;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;

namespace CelsoMusic.Test.Application.Musica
{
    public class MusicaServiceTest
    {
        [Fact]
        public async Task DeveCriarMusicaComSucesso()
        {
            var dto = new MusicaInputDTO("Musica ABC", "", 100);
            var mockRepository = new Mock<IMusicaRepository>();
            var mockAlbumRepository = new Mock<IAlbumRepository>();
            var mockMapper = new Mock<IMapper>();

            var musica = new MusicaModel()
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Duracao = new Duracao(dto.Duracao)
            };

            var musicaDTO = new MusicaOutputDTO(Guid.NewGuid(), musica.Nome, musica.Descricao, musica.Duracao.Formatada);

            mockMapper.Setup(x => x.Map<MusicaModel>(dto)).Returns(musica);
            mockMapper.Setup(x => x.Map<MusicaOutputDTO>(musica)).Returns(musicaDTO);

            mockRepository.Setup(x => x.Save(It.IsAny<MusicaModel>())).Returns(Task.FromResult(musica));
            mockAlbumRepository.Setup(x => x.Get(It.IsAny<Album>())).Returns(Task.FromResult(new Album()));

            var service = new MusicaService(mockRepository.Object, mockAlbumRepository.Object, mockMapper.Object);

            var result = await service.Criar(dto, Guid.NewGuid());

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeveAtualizarMusicaComSucesso()
        {
            var dto = new MusicaUpdateDTO(Guid.NewGuid(), "Musica ABC", "", 200);
            var mockRepository = new Mock<IMusicaRepository>();
            var mockAlbumRepository = new Mock<IAlbumRepository>();
            var mockMapper = new Mock<IMapper>();

            var musica = new MusicaModel()
            {
                ID = dto.ID,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Duracao = new Duracao(dto.Duracao)
            };

            var musicaDTO = new MusicaOutputDTO(Guid.NewGuid(), musica.Nome, musica.Descricao, musica.Duracao.Formatada);

            mockMapper.Setup(x => x.Map<MusicaModel>(dto)).Returns(musica);
            mockMapper.Setup(x => x.Map<MusicaOutputDTO>(musica)).Returns(musicaDTO);

            mockRepository.Setup(x => x.Update(It.IsAny<MusicaModel>())).Returns(Task.FromResult(musica));
            mockAlbumRepository.Setup(x => x.Get(It.IsAny<Album>())).Returns(Task.FromResult(new Album()));

            var service = new MusicaService(mockRepository.Object, mockAlbumRepository.Object, mockMapper.Object);

            var result = await service.Atualizar(dto);

            Assert.NotNull(result);
        }
    }
}
