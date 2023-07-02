namespace Crm.Api.Queries.Recherche
{
    /// <summary>
    /// Représente un tri de données.
    /// </summary>
    public sealed class Tri
    {
        /// <summary>
        /// Le nom du champ à trier.
        /// </summary>
        public string? Champ { get; set; }

        /// <summary>
        /// Indique si le tri est ascendant ou pas.
        /// </summary>
        public bool Ascendant { get; set; }
    }
}