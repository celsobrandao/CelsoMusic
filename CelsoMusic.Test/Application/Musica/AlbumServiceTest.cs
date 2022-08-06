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
    public class AlbumServiceTest
    {
        [Fact]
        public async Task DeveCriarAlbumComSucesso()
        {
            var dto = new AlbumInputDTO("Album ABC", DateTime.Now, "Album de metal nórdico", "foto.jpg", GetMusicas());
            var mockRepository = new Mock<IAlbumRepository>();
            var mockArtistaRepository = new Mock<IArtistaRepository>();
            var mockMapper = new Mock<IMapper>();

            var album = new Album()
            {
                Nome = dto.Nome,
                DataLancamento = dto.DataLancamento,
                Descricao = dto.Descricao,
                Imagem = dto.Imagem,
                Musicas = dto.Musicas.Select(m => new MusicaModel { Nome = m.Nome, Descricao = m.Descricao, Duracao = new Duracao(m.Duracao) }).ToList()
            };

            var albumDTO = new AlbumOutputDTO(Guid.NewGuid(), album.Nome, album.DataLancamento, album.Descricao, album.Imagem, album.Musicas.Select(m => new MusicaOutputDTO(Guid.NewGuid(), m.Nome, m.Descricao, m.Duracao.Formatada)).ToList());

            mockMapper.Setup(x => x.Map<Album>(dto)).Returns(album);
            mockMapper.Setup(x => x.Map<AlbumOutputDTO>(album)).Returns(albumDTO);

            mockRepository.Setup(x => x.Save(It.IsAny<Album>())).Returns(Task.FromResult(album));
            mockArtistaRepository.Setup(x => x.Get(It.IsAny<Artista>())).Returns(Task.FromResult(new Artista()));

            var service = new AlbumService(mockRepository.Object, mockArtistaRepository.Object, mockMapper.Object);

            var result = await service.Criar(dto, Guid.NewGuid());

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeveAtualizarAlbumComSucesso()
        {
            var dto = new AlbumUpdateDTO(Guid.NewGuid(), "Album ABC", DateTime.Now, "Album de metal nórdico", "foto.jpg", GetMusicas());
            var mockRepository = new Mock<IAlbumRepository>();
            var mockArtistaRepository = new Mock<IArtistaRepository>();
            var mockMapper = new Mock<IMapper>();

            var album = new Album()
            {
                ID = dto.ID,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Imagem = dto.Imagem,
                Musicas = dto.Musicas.Select(m => new MusicaModel { Nome = m.Nome, Descricao = m.Descricao, Duracao = new Duracao(m.Duracao) }).ToList()
            };

            var albumDTO = new AlbumOutputDTO(Guid.NewGuid(), album.Nome, album.DataLancamento, album.Descricao, album.Imagem, album.Musicas.Select(m => new MusicaOutputDTO(Guid.NewGuid(), m.Nome, m.Descricao, m.Duracao.Formatada)).ToList());

            mockMapper.Setup(x => x.Map<Album>(dto)).Returns(album);
            mockMapper.Setup(x => x.Map<AlbumOutputDTO>(album)).Returns(albumDTO);

            mockRepository.Setup(x => x.Update(It.IsAny<Album>())).Returns(Task.FromResult(album));
            mockArtistaRepository.Setup(x => x.Get(It.IsAny<Artista>())).Returns(Task.FromResult(new Artista()));

            var service = new AlbumService(mockRepository.Object, mockArtistaRepository.Object, mockMapper.Object);

            var result = await service.Atualizar(dto);

            Assert.NotNull(result);
        }

        private static List<MusicaInputDTO> GetMusicas()
        {
            return new List<MusicaInputDTO> { new("Musica 1", "", 100), new("Musica 2", "", 200) };
        }
    }
}
