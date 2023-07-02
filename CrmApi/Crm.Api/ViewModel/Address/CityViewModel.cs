namespace IDSoft.TopInvestV6.Domain.ViewModels
{
    /// <summary>
    /// Représente une ville.
    /// </summary>
    public class CityViewModel
    {
        /// <summary>
        /// L'identifiant de la ville.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Le nom de la ville.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// L'identifiant du département de la ville.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Le code postal de la ville.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Le code INSEE de la ville.
        /// </summary>
        public string InseeCode { get; set; }
    }
}
