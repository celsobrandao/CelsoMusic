using CelsoMusic.Domain.Musica.ValueObject;
using CelsoMusic.Infra.Entidade;

namespace CelsoMusic.Domain.Musica
{
    public class Album : Entidade<Guid>
    {
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }

        public Duracao Duracao => new(Musicas.Sum(m => m.Duracao.Valor));

        public List<Musica> Musicas { get; set; }
        public List<Genero> Generos => Musicas.SelectMany(m => m.Generos).Distinct().ToList();
    }
}