using CelsoMusic.Domain.Usuario;

namespace CelsoMusic.Domain.Factory.Usuario
{
    public static class PlaylistFactory
    {
        public static Playlist Criar(string nome)
        {
            return new Playlist
            {
                Nome = nome
            };
        }
    }
}
