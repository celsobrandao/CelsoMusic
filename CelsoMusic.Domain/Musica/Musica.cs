using CelsoMusic.Domain.Musica.ValueObject;
using CelsoMusic.Infra.Entidade;
using PlaylistModel = CelsoMusic.Domain.Playlist.Playlist;

namespace CelsoMusic.Domain.Musica
{
    public class Musica : Entidade<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Duracao Duracao { get; set; }
        public string Audio { get; set; }

        public Album Album { get; set; }
        public List<PlaylistModel> Playlists { get; set; }
    }
}
