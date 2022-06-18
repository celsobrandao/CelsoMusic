using CelsoMusic.Domain.Musica.ValueObject;
using CelsoMusic.Infra.Entidade;

namespace CelsoMusic.Domain.Musica
{
    public class Musica : Entidade<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Duracao Duracao { get; set; }
        public string Audio { get; set; }

        public List<Genero> Generos { get; set; }
    }
}
