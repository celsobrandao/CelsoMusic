using CelsoMusic.Domain.Factory.Musica;
using CelsoMusic.Infra.Entidade;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelsoMusic.Domain.Musica
{
    public class Artista : Entidade<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }

        public List<Album> Albuns { get; set; }

        [NotMapped]
        public int QuantidadeAlbuns => Albuns == null ? 0 : Albuns.Count;

        public void CriarAlbum(string nome, List<Musica> musicas)
        {
            Albuns.Add(AlbumFactory.Criar(nome, musicas));
        }
    }
}