using Crm.Api.Infrastructure.Entities;
using Crm.Api.Services;
using FluentValidation.Results;
using IDSoft.CrmWelcome.Domain.Abstractions.Services;

namespace Crm.Api.Infrastructure.Services
{
    public class VerifieurReferencesService: IVerifieurReferencesService
    {
        private readonly ICrmService _crmService;

        public VerifieurReferencesService(ICrmService crmService)
        {
           _crmService = crmService ?? throw new ArgumentNullException(nameof(crmService));
        }

        public async Task<List<ValidationFailure>> VerifieAsync(params Func<Task<ValidationFailure>>[] verifieursAsync)
        {
            var failures = new List<ValidationFailure>();

            foreach (var verifieurAsync in verifieursAsync)
            {
                var failure = await verifieurAsync();
                if (failure != null)
                    failures.Add(failure);
            }

            return failures;
        }

        public Task<ValidationFailure> VerifieExistenceCityAsync(int id, CancellationToken cancellationToken) => _crmService.VerifieExistenceEtTypeAsync(nameof(CityEntity.Id), id, typeof(CityEntity), cancellationToken);
    }
}
