using CelsoMusic.Domain.Usuario.ValueObject;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CelsoMusic.Domain.Usuario.Rules
{
    public class ValidadorEmail : AbstractValidator<Email>
    {
        private const string _padrao = @"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i";

        public ValidadorEmail()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .Must(EmailValido)
                .WithMessage("Email inválido.");
        }

        private bool EmailValido(string valor) => Regex.IsMatch(valor, _padrao);
    }
}
