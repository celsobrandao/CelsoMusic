using CelsoMusic.Domain.Musica;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;

namespace CelsoMusic.Domain.Factory.Musica
{
    public static class AlbumFactory
    {
        public static Album Criar(string nome, List<MusicaModel> musicas)
        {
            if (!musicas.Any())
                throw new ArgumentNullException("Um album deve possuir pelo menos uma música.");

            return new Album
            {
                Nome = nome,
                Musicas = musicas
            };
        }
    }
}
