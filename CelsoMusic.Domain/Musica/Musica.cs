using CelsoMusic.Domain.Musica.ValueObject;
using CelsoMusic.Domain.Usuario;
using CelsoMusic.Infra.Entidade;

namespace CelsoMusic.Domain.Musica
{
    public class Musica : Entidade<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Duracao Duracao { get; set; }
        public string Audio { get; set; }

        public Album Album { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}
