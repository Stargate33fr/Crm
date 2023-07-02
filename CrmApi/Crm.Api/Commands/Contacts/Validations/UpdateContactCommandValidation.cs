using FluentValidation;
using IDSoft.CrmWelcome.Api.Commands.FoyersFiscaux;

namespace Crm.Api.Commands.Contacts.Validations
{
    public class UpdateContactCommandValidation : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidation()
        {
            RuleFor(ff => ff.Id).GreaterThan(0).WithMessage("L'identifiant du contact n'est pas défini");
        }
    }
}
