using AutoMapper;
using Crm.Api.Infrastructure.MediatR;
using Crm.Api.Services;
using IDSoft.CrmWelcome.Api.Queries.GeoLocalisation;

namespace Crm.Api.Queries.GeoLocalisation
{
    public class ObtenirElementsRechercheGeoQueryHandler : QueryHandlerBase<ObtenirElementsRechercheGeoQuery, ListeElementsRechercheGeo>
    {
        private readonly ILocalisationService _localisationService;

        public ObtenirElementsRechercheGeoQueryHandler(ILocalisationService localisationService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(mapper, httpContextAccessor)
        {
            _localisationService = localisationService;
        }

        public override async Task<ListeElementsRechercheGeo> Handle(ObtenirElementsRechercheGeoQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Recherche))
            {
                return new ListeElementsRechercheGeo
                {
                    Contenu = await _localisationService.GetLocalisationsAsync(request.Recherche, cancellationToken)
                };
            }
            else
            {
                return new ListeElementsRechercheGeo
                {
                    Contenu = null
                };
            }
        }
    }
}
