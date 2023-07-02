using FluentValidation;
using IDSoft.CrmWelcome.Api.Commands.FoyersFiscaux;

namespace Crm.Api.Commands.User.Validations
{
    public class UpdateUserCommandValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            RuleFor(ff => ff.Id).GreaterThan(0).WithMessage("L'identifiant du user n'est pas défini");
        }
    }
}
