using AutoMapper;
using Crm.Api.Infrastructure.MediatR;
using Crm.Api.Services;
using FluentValidation.Results;
using IDSoft.CrmWelcome.Domain.Abstractions.Services;

namespace IDSoft.CrmWelcome.Api.Commands.FoyersFiscaux
{
    public class UpdateUserCommandHandler : CommandHandlerBase<UpdateUserCommand>
    {
        private readonly ICrmService _crmService;
        public UpdateUserCommandHandler(ICrmService crmService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IVerifieurReferencesService verifieurReferenceService, ILoggerFactory loggerFactory)
            : base(mapper, httpContextAccessor, verifieurReferenceService, loggerFactory)
        {
            _crmService = crmService ?? throw new ArgumentNullException(nameof(crmService));
        }

        protected override List<Func<Task<ValidationFailure>>> DefinitLesVerifieurs(UpdateUserCommand commande, CancellationToken cancellationToken)
        {
            var validations = new List<Func<Task<ValidationFailure>>>
            {
                () => VerifieurReferenceService.VerifieExistenceCityAsync(commande.CityId, cancellationToken)
            };
         
            return validations;
        }

        protected override async Task ExecuteCommandeAsync(UpdateUserCommand commande, CancellationToken cancellationToken)
        {
            var user = await _crmService.GetUserByIdAsync(commande.Id, cancellationToken);
            if (user != null)
            {
                user.FirstName = commande.FirstName;
                user.LastName = commande.LastName;
                user.PhoneNumber = commande.PhoneNumber;
                user.MobilePhoneNumber = commande.MobilePhoneNumber;
                
                if (user.Address != null)
                {
                    user.Address.CityId = commande.CityId;
                    user.Address.ComplementStreet = commande.ComplementStreet;
                    user.Address.Street = commande.Street;
                }
                await _crmService.UpdateUser(user, cancellationToken);
            }
        }
    }
}
