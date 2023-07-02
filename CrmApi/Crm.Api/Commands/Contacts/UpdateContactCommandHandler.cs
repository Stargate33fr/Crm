using AutoMapper;
using Crm.Api.Infrastructure.MediatR;
using Crm.Api.Services;
using FluentValidation.Results;
using IDSoft.CrmWelcome.Domain.Abstractions.Services;

namespace IDSoft.CrmWelcome.Api.Commands.FoyersFiscaux
{
    public class UpdateContactCommandHandler : CommandHandlerBase<UpdateContactCommand>
    {
        private readonly ICrmService _crmService;
        public UpdateContactCommandHandler(ICrmService crmService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IVerifieurReferencesService verifieurReferenceService, ILoggerFactory loggerFactory)
            : base(mapper, httpContextAccessor, verifieurReferenceService, loggerFactory)
        {
            _crmService = crmService ?? throw new ArgumentNullException(nameof(crmService));
        }

        protected override List<Func<Task<ValidationFailure>>> DefinitLesVerifieurs(UpdateContactCommand commande, CancellationToken cancellationToken)
        {
            var validations = new List<Func<Task<ValidationFailure>>>
            {
                () => VerifieurReferenceService.VerifieExistenceCityAsync(commande.CityId, cancellationToken)
            };
         
            return validations;
        }

        protected override async Task ExecuteCommandeAsync(UpdateContactCommand commande, CancellationToken cancellationToken)
        {
            var contact = await _crmService.GetContactByIdAsync(commande.Id, cancellationToken);
            if (contact != null)
            {
                contact.FirstName = commande.FirstName;
                contact.LastName = commande.LastName;
                contact.PhoneNumber = commande.PhoneNumber;
                contact.MobilePhoneNumber = commande.MobilePhoneNumber;
                contact.ConseillerId = commande.IdConseiller;

                if (contact.Address != null)
                {
                    contact.Address.CityId = commande.CityId;
                    contact.Address.ComplementStreet = commande.ComplementStreet;
                    contact.Address.Street = commande.Street;
                }
                await _crmService.UpdateContact(contact, cancellationToken);
            }
        }
    }
}
