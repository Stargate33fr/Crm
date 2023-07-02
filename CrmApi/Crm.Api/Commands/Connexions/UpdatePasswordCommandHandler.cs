using AutoMapper;
using Crm.Api.Commands.Connexions;
using Crm.Api.Infrastructure.Helpers;
using Crm.Api.Infrastructure.MediatR;
using Crm.Api.Services;
using FluentValidation.Results;
using IDSoft.CrmWelcome.Domain.Abstractions.Services;

namespace IDSoft.CrmWelcome.Api.Commands.Connexions
{
    public class UpdatePasswordCommandHandler: CommandHandlerBase<UpdatePasswordCommand>
    {
        private readonly ICrmService _crmService;

        public UpdatePasswordCommandHandler(ICrmService crmService, IMapper mapper, IVerifieurReferencesService verifieurReferenceService, IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory)
          : base(mapper, httpContextAccessor, verifieurReferenceService, loggerFactory)
        {
            _crmService = crmService ?? throw new ArgumentNullException(nameof(crmService));
        }

        protected override List<Func<Task<ValidationFailure>>>? DefinitLesVerifieurs(UpdatePasswordCommand commande, CancellationToken cancellationToken)
        {
            return null;
        }

        protected override async Task ExecuteCommandeAsync(UpdatePasswordCommand command, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(command.Login) && !string.IsNullOrEmpty(command.Password))
            {
                var utilisateurDto = await _crmService.GetByEmailAsync(command.Login, cancellationToken);

                if (utilisateurDto != null)
                {
                    utilisateurDto.Password = command.Password.ChiffrerChaine();

                    await _crmService.UpdateUser(utilisateurDto, cancellationToken);
                }
            }
        }
    }
}
