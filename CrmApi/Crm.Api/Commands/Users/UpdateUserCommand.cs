using Crm.Api.Commands.User.Validations;
using Crm.Api.Infrastructure.MediatR;
using FluentValidation.Results;

namespace IDSoft.CrmWelcome.Api.Commands.FoyersFiscaux
{
    public class UpdateUserCommand : Command
    {
        public override ValidationResult Valide()
        {
            return new UpdateUserCommandValidation().Validate(this);
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Street { get; set; }
        public string? ComplementStreet { get; set; }
        public int CityId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobilePhoneNumber { get; set; }
    }
}
