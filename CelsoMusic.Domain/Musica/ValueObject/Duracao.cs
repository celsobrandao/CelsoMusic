namespace CelsoMusic.Domain.Musica.ValueObject
{
    public class Duracao
    {
        public Duracao()
        {
        }

        public Duracao(int valor)
        {
            Valor = valor;
        }

        public int Valor { get; set; }

        public string Formatada => TimeSpan.FromMinutes(Valor).ToString(@"hh\:mm\:ss");

    }
}
