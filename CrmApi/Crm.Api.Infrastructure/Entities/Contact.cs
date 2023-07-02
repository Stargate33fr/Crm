using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Infrastructure.Entities
{
    public class ContactEntity : TrackedEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? AddressId { get; set; }

        public int? CompanyId { get; set; }

        public int? ConseillerId { get; set; }

        public string? Mail { get; set; }

        [StringLength(255)]
        public string? PhoneNumber { get; set; }

        [StringLength(255)]
        public string? MobilePhoneNumber { get; set; }

        public virtual AddressEntity? Address { get; set; }

        public virtual UserEntity? Conseiller { get; set; }

        public virtual CompanyEntity? Company { get; set; }
    }
}
