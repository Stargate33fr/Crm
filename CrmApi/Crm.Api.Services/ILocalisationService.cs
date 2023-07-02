using Crm.Api.Domain.Abstractions.Dtos.GeoLocalisation;

namespace Crm.Api.Services
{
    public interface ILocalisationService
    {
        Task<IReadOnlyCollection<KeyValuePair<string, string>>> GetLocalisationsAsync(string pattern, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<IElementRechercheGeo>> ObtenirToutesVillesAvecCodePostalPourRechercheAsync(CancellationToken cancellationToken);
        Task<IReadOnlyCollection<IElementRechercheGeo>> ObtenirTousDepartmentsPourRechercheAsync(CancellationToken cancellationToken);
        Task<IReadOnlyCollection<IElementRechercheGeo>> ObtenirToutesRegionsPourRechercheAsync(CancellationToken cancellationToken);
    }
}
