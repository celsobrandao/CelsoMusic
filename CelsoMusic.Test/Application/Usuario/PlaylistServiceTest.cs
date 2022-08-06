using AutoMapper;
using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Usuario.DTO;
using CelsoMusic.Application.Usuario.Service;
using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Domain.Usuario;
using CelsoMusic.Domain.Usuario.Repository;
using Moq;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;
using UsuarioModel = CelsoMusic.Domain.Usuario.Usuario;

namespace CelsoMusic.Test.Application.Usuario
{
    public class PlaylistServiceTest
    {
        [Fact]
        public async Task DeveCriarPlaylistComSucesso()
        {
            var dto = new PlaylistInputDTO("Playlist ABC", "Playlist de metal nórdico", GetMusicas());
            var mockRepository = new Mock<IPlaylistRepository>();
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            var mockMusicaRepository = new Mock<IMusicaRepository>();
            var mockMapper = new Mock<IMapper>();

            var playlist = new Playlist()
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Musicas = dto.MusicaIDs.Select(m => new MusicaModel { ID = m, Nome = "", Descricao = "", Duracao = new(100) }).ToList()
            };

            var playlistDTO = new PlaylistOutputDTO(Guid.NewGuid(), playlist.Nome, playlist.Descricao, playlist.Musicas.Select(m => new MusicaOutputDTO(Guid.NewGuid(), m.Nome, m.Descricao, m.Duracao.Formatada)).ToList());

            mockMapper.Setup(x => x.Map<Playlist>(dto)).Returns(playlist);
            mockMapper.Setup(x => x.Map<PlaylistOutputDTO>(playlist)).Returns(playlistDTO);

            mockRepository.Setup(x => x.Save(It.IsAny<Playlist>())).Returns(Task.FromResult(playlist));
            mockUsuarioRepository.Setup(x => x.Get(It.IsAny<UsuarioModel>())).Returns(Task.FromResult(new UsuarioModel()));
            mockMusicaRepository.Setup(x => x.Get(It.IsAny<MusicaModel>())).Returns(Task.FromResult(new MusicaModel()));

            var service = new PlaylistService(mockRepository.Object, mockUsuarioRepository.Object, mockMusicaRepository.Object, mockMapper.Object);

            var result = await service.Criar(dto, Guid.NewGuid());

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeveAtualizarComSucesso()
        {
            var dto = new PlaylistUpdateDTO(Guid.NewGuid(), "Playlist ABC", "Playlist de metal nórdico", GetMusicas());
            var mockRepository = new Mock<IPlaylistRepository>();
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            var mockMusicaRepository = new Mock<IMusicaRepository>();
            var mockMapper = new Mock<IMapper>();

            var playlist = new Playlist()
            {
                ID = dto.ID,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Musicas = dto.MusicaIDs.Select(m => new MusicaModel { ID = m, Nome = "", Descricao = "", Duracao = new(100) }).ToList()
            };

            var playlistDTO = new PlaylistOutputDTO(Guid.NewGuid(), playlist.Nome, playlist.Descricao, playlist.Musicas.Select(m => new MusicaOutputDTO(Guid.NewGuid(), m.Nome, m.Descricao, m.Duracao.Formatada)).ToList());

            mockMapper.Setup(x => x.Map<Playlist>(dto)).Returns(playlist);
            mockMapper.Setup(x => x.Map<PlaylistOutputDTO>(playlist)).Returns(playlistDTO);

            mockRepository.Setup(x => x.Update(It.IsAny<Playlist>())).Returns(Task.FromResult(playlist));
            mockUsuarioRepository.Setup(x => x.Get(It.IsAny<UsuarioModel>())).Returns(Task.FromResult(new UsuarioModel()));
            mockMusicaRepository.Setup(x => x.Get(It.IsAny<MusicaModel>())).Returns(Task.FromResult(new MusicaModel()));

            var service = new PlaylistService(mockRepository.Object, mockUsuarioRepository.Object, mockMusicaRepository.Object, mockMapper.Object);

            var result = await service.Atualizar(dto);

            Assert.NotNull(result);
        }

        private static List<Guid> GetMusicas()
        {
            return new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
        }
    }
}
