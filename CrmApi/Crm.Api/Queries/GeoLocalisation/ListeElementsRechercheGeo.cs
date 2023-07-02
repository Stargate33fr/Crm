using Crm.Api.Domain.Abstractions.Queries;

namespace IDSoft.CrmWelcome.Api.Queries.GeoLocalisation
{
    public class ListeElementsRechercheGeo : IResponse<IReadOnlyCollection<KeyValuePair<string, string>>>
    {
        public IReadOnlyCollection<KeyValuePair<string, string>>? Contenu { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
