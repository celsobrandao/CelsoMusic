using CelsoMusic.Domain.Musica.ValueObject;
using CelsoMusic.Infra.Entidade;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelsoMusic.Domain.Musica
{
    public class Album : Entidade<Guid>
    {
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }

        public List<Musica> Musicas { get; set; }

        [NotMapped]
        public Duracao Duracao => new(Musicas == null ? 0 : Musicas.Sum(m => m.Duracao.Valor));
        [NotMapped]
        public List<Genero> Generos => Musicas == null ? new List<Genero>() : Musicas.SelectMany(m => m.Generos).Distinct().ToList();
        [NotMapped]
        public string DescricaoGeneros => string.Join(", ", Generos);
        [NotMapped]
        public string DescricaoMusicas => Musicas == null ? "" : string.Join(", ", Musicas.Select(m => m.Nome));
    }
}