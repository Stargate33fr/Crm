using Crm.Api.Commands.Connexions.Validation;
using Crm.Api.Infrastructure.MediatR;
using FluentValidation.Results;


namespace Crm.Api.Commands.Connexions
{
    public class UpdatePasswordCommand : Command
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public override ValidationResult Valide()
        {
            return new UpdatePasswordCommandValidation().Validate(this);
        }
    }
}
