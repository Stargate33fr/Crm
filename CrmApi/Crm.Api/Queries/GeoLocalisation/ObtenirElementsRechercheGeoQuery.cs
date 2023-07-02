using IDSoft.CrmWelcome.Api.Queries.GeoLocalisation;
using MediatR;

namespace Crm.Api.Queries.GeoLocalisation
{
    public class ObtenirElementsRechercheGeoQuery : IRequest<ListeElementsRechercheGeo>
    {
        public string? Recherche { get; set; }
    }
}
