using System.Collections.Generic;

namespace IDSoft.TopInvestV6.Domain.ViewModels
{
    public class DepartmentViewModel
    {
        /// <summary>
        /// L'identifiant du département.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// L'identifiant de la région du département.
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// Le nom du département.
        /// </summary>
        public string? Nom { get; set; }

        /// <summary>
        /// Le code du département.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        public RegionViewModel? Region { get; set; }

        /// <summary>
        /// Liste des villes
        /// </summary>
        public virtual ICollection<CityViewModel> Villes { get; set; } = new HashSet<CityViewModel>();
    }
}
