using CelsoMusic.Domain.Factory.Usuario;
using CelsoMusic.Domain.Usuario.Rules;
using CelsoMusic.Domain.Usuario.ValueObject;
using CelsoMusic.Infra.Entidade;
using CelsoMusic.Infra.Utils;
using FluentValidation;

namespace CelsoMusic.Domain.Usuario
{
    public class Usuario : Entidade<Guid>
    {
        public Email Email { get; set; }
        public Senha Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid UltimaMusicaID { get; set; }
        public int UltimaMusicaTempo { get; set; }
        public Guid UltimaPlaylistID { get; set; }

        public List<Playlist> Playlists { get; set; }

        public void Validar() => new ValidadorUsuario().ValidateAndThrow(this);

        public void AtualizarSenha()
        {
            Senha.Valor = SegurancaUtils.HashSHA1(Senha.Valor);
        }

        public void CriarPlaylist(string nome)
        {
            Playlists.Add(PlaylistFactory.Criar(nome));
        }
    }
}