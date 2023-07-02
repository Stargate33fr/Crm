using Crm.Api.Domain.Abstractions.Dtos.GeoLocalisation;

namespace Crm.Api.Domain.Abstractions.GeoLocalisation
{
    public class ElementRechercheGeo : IElementRechercheGeo
    {
        public string? TextForLocalisation { get; set; }
        public string? ValueForLocalisation { get; set; }
        public string? SearchForLocalisation { get; set; }
        public string? SearchForCodePostal { get; set; }
        public string? SearchForVille { get; set; }
    }
}
