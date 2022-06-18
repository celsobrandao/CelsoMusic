using CelsoMusic.Domain.Musica.ValueObject;
using CelsoMusic.Infra.Entidade;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;

namespace CelsoMusic.Domain.Usuario
{
    public class Playlist : Entidade<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<MusicaModel> Musicas { get; set; }
        public Duracao Duracao => new(Musicas.Sum(m => m.Duracao.Valor));
    }
}
