using AutoMapper;
using CelsoMusic.Application.Musica.DTO;
using CelsoMusic.Application.Playlist.DTO;
using CelsoMusic.Application.Playlist.Service;
using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Domain.Playlist.Repository;
using Moq;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;
using PlaylistModel = CelsoMusic.Domain.Playlist.Playlist;

namespace CelsoMusic.Test.Application.Playlist
{
    public class PlaylistServiceTest
    {
        [Fact]
        public async Task DeveCriarPlaylistComSucesso()
        {
            var usuarioID = Guid.NewGuid();
            var dto = new PlaylistInputDTO(usuarioID, "Playlist ABC", "Playlist de metal nórdico", GetMusicas());
            var mockRepository = new Mock<IPlaylistRepository>();
            var mockMusicaRepository = new Mock<IMusicaRepository>();
            var mockMapper = new Mock<IMapper>();

            var playlist = new PlaylistModel()
            {
                UsuarioID = usuarioID,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Musicas = dto.MusicaIDs.Select(m => new MusicaModel { ID = m, Nome = "", Descricao = "", Duracao = new(100) }).ToList()
            };

            var playlistDTO = new PlaylistOutputDTO(Guid.NewGuid(), playlist.Nome, playlist.Descricao, playlist.Musicas.Select(m => new MusicaOutputDTO(Guid.NewGuid(), m.Nome, m.Descricao, m.Duracao.Formatada)).ToList());

            mockMapper.Setup(x => x.Map<PlaylistModel>(dto)).Returns(playlist);
            mockMapper.Setup(x => x.Map<PlaylistOutputDTO>(playlist)).Returns(playlistDTO);

            mockRepository.Setup(x => x.Save(It.IsAny<PlaylistModel>())).Returns(Task.FromResult(playlist));
            mockMusicaRepository.Setup(x => x.Get(It.IsAny<MusicaModel>())).Returns(Task.FromResult(new MusicaModel()));

            var service = new PlaylistService(mockRepository.Object, mockMusicaRepository.Object, mockMapper.Object);

            var result = await service.Criar(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeveAtualizarComSucesso()
        {
            var dto = new PlaylistUpdateDTO(Guid.NewGuid(), "Playlist ABC", "Playlist de metal nórdico", GetMusicas());
            var mockRepository = new Mock<IPlaylistRepository>();
            var mockMusicaRepository = new Mock<IMusicaRepository>();
            var mockMapper = new Mock<IMapper>();

            var playlist = new PlaylistModel()
            {
                ID = dto.ID,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Musicas = dto.MusicaIDs.Select(m => new MusicaModel { ID = m, Nome = "", Descricao = "", Duracao = new(100) }).ToList()
            };

            var playlistDTO = new PlaylistOutputDTO(Guid.NewGuid(), playlist.Nome, playlist.Descricao, playlist.Musicas.Select(m => new MusicaOutputDTO(Guid.NewGuid(), m.Nome, m.Descricao, m.Duracao.Formatada)).ToList());

            mockMapper.Setup(x => x.Map<PlaylistModel>(dto)).Returns(playlist);
            mockMapper.Setup(x => x.Map<PlaylistOutputDTO>(playlist)).Returns(playlistDTO);

            mockRepository.Setup(x => x.Update(It.IsAny<PlaylistModel>())).Returns(Task.FromResult(playlist));
            mockMusicaRepository.Setup(x => x.Get(It.IsAny<MusicaModel>())).Returns(Task.FromResult(new MusicaModel()));

            var service = new PlaylistService(mockRepository.Object, mockMusicaRepository.Object, mockMapper.Object);

            var result = await service.Atualizar(dto);

            Assert.NotNull(result);
        }

        private static List<Guid> GetMusicas()
        {
            return new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
        }
    }
}
