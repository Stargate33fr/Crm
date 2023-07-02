using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.Api.Commands.Connexions.Validation
{
    public class UpdatePasswordCommandValidation : AbstractValidator<UpdatePasswordCommand>
    {
        public UpdatePasswordCommandValidation()
        {
            RuleFor(c => c.Login).NotEmpty()
                .WithMessage("Le login doit être renseigné");

            RuleFor(c => c.Password).NotEmpty()
               .WithMessage("Le mot de passe doit être renseigné");

        }
    }
}
