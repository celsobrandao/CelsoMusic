using CelsoMusic.Infra.Entidade;

namespace CelsoMusic.Domain.Musica
{
    public class Genero : Entidade<Guid>
    {
        public string Nome { get; set; }

        public List<Musica> Musicas { get; set; }
    }
}
