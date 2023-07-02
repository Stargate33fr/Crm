namespace Crm.Api.Queries.Recherche
{
    /// <summary>
    /// Représente une pagination.
    /// </summary>
    public sealed class Pagination
    {
        /// <summary>
        /// Le nombre d'élément dans la page.
        /// </summary>
        public int Limite { get; set; }

        /// <summary>
        /// L'index de la page.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Le nombre d'élément à sauter dans le retour.
        /// </summary>
        public int Skip => Index * Limite;
    }
}