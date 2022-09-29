using PlaylistModel=  CelsoMusic.Domain.Playlist.Playlist;

namespace CelsoMusic.Domain.Factory.Playlist
{
    public static class PlaylistFactory
    {
        public static PlaylistModel Criar(string nome)
        {
            return new PlaylistModel
            {
                Nome = nome
            };
        }
    }
}
