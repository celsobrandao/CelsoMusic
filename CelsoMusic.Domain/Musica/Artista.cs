using CelsoMusic.Domain.Factory.Musica;
using CelsoMusic.Infra.Entidade;

namespace CelsoMusic.Domain.Musica
{
    public class Artista : Entidade<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }

        public List<Album> Albuns { get; set; }
        public List<Genero> Generos => Albuns.SelectMany(m => m.Generos).Distinct().ToList();

        public void CriarAlbum(string nome, List<Musica> musicas)
        {
            Albuns.Add(AlbumFactory.Criar(nome, musicas));
        }
    }
}