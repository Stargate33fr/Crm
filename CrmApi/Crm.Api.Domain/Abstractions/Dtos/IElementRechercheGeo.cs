namespace Crm.Api.Domain.Abstractions.Dtos.GeoLocalisation
{
    public interface IElementRechercheGeo
    {
        string? TextForLocalisation { get; set; }
        string? ValueForLocalisation { get; set; }
        string? SearchForLocalisation { get; set; }
        string? SearchForCodePostal { get; set; }
        string? SearchForVille { get; set; }
    }
}
