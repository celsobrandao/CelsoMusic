using CelsoMusic.Domain.Musica.ValueObject;
using CelsoMusic.Domain.Usuario;
using CelsoMusic.Infra.Entidade;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelsoMusic.Domain.Musica
{
    public class Musica : Entidade<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Duracao Duracao { get; set; }
        public string Audio { get; set; }

        public List<Genero> Generos { get; set; }
        public List<Playlist> Playlists { get; set; }

        [NotMapped]
        public string DescricaoGeneros => Generos == null ? "" : string.Join(", ", Generos);
    }
}
