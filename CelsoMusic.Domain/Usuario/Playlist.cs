﻿using CelsoMusic.Domain.Musica.ValueObject;
using CelsoMusic.Infra.Entidade;
using System.ComponentModel.DataAnnotations.Schema;
using MusicaModel = CelsoMusic.Domain.Musica.Musica;

namespace CelsoMusic.Domain.Usuario
{
    public class Playlist : Entidade<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<MusicaModel> Musicas { get; set; }
        public Usuario Usuario { get; set; }

        [NotMapped]
        public Duracao Duracao => new(Musicas == null ? 0 : Musicas.Sum(m => m.Duracao.Valor));
    }
}
