using AutoMapper;
using Crm.Api.Infrastructure.MediatR;
using Crm.Api.Queries.DonneesReference;
using Crm.Api.Services;
using Crm.Api.ViewModel.Habilitations;
using Crm.Api.ViewModels.DonneeReference;

namespace Crm.Api.Queries.Utilisateurs
{
    public class GetCivilitiesQueryHandler : QueryHandlerBase<GetCivilitiesQuery, ListeValeursResponse?>
    {
        private readonly ICrmService _crmService;
        public GetCivilitiesQueryHandler(ICrmService crmService, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _crmService = crmService ?? throw new ArgumentNullException(nameof(crmService));
        }

        public override async Task<ListeValeursResponse?> Handle(GetCivilitiesQuery request, CancellationToken cancellationToken)
        {
            var civilites = await _crmService.GetCivilities(cancellationToken);

            var liste = Mapper.Map<IReadOnlyCollection<ValeurViewModel>>(civilites?.Select(v => new ValeurViewModel
            {
                Id = v.Id,
                Libelle = v.LongName,
                ValeurAssociee = v.ShortName,
                EstVisible = true
            }));

            return new ListeValeursResponse
            {
                Total = liste.Count,
                Contenu = liste
            };
        }
    }
}
