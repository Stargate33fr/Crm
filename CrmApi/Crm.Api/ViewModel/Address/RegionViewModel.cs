namespace IDSoft.TopInvestV6.Domain.ViewModels
{
    /// <summary>
    /// Représente une région.
    /// </summary>
    public class RegionViewModel
    {
        /// <summary>
        /// L'identifiant de la région.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Le nom de la région.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// L'identifiant du pays.
        /// </summary>
        public int PaysId { get; set; }
    }
}
