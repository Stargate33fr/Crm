namespace IDSoft.TopInvestV6.Domain.ViewModels
{
    /// <summary>
    /// Représente une adresse.
    /// </summary>
    public class AddressViewModel
    {
        /// <summary>
        /// La voie de l'adresse.
        /// </summary>
        public string? Street { get; set; }

        /// <summary>
        /// Le complément de voie de l'adresse.
        /// </summary>
        public string? StreetComplement { get; set; }

        /// <summary>
        /// Le code postal de l'adresse.
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Le nom de la ville de l'adresse.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Le nom du département de l'adresse.
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// Le nom du département de l'adresse.
        /// </summary>
        public string? Region { get; set; }

        /// <summary>
        /// Le nom du département de l'adresse.
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Le code du département de l'adresse.
        /// </summary>
        public string? CodeDepartement { get; set; }

        /// <summary>
        /// L'identifiant de la ville de l'utilisateur.
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// L'identifiant du département de l'utilisateur.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// L'identifiant de la région de l'utilisateur.
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// L'identifiant du Pays de l'utilisateur.
        /// </summary>
        public int CountryId { get; set; }
    }
}
