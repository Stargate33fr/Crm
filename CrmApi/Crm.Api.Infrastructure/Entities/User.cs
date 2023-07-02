using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Api.Infrastructure.Entities
{
    public class UserEntity : TrackedEntity
    {
        public int Id { get; set; }

        public int? CivilityId { get; set; }

        public int? AddressId { get; set; }
        
        public string? LastName {get;set;}

        public string? FirstName { get; set; }

        [StringLength(255)]
        public string? PhoneNumber { get; set; }

        [StringLength(255)]
        public string? MobilePhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string? Mail { get; set; }

        public string? Password { get; set; }
    
        public bool Actif { get; set; }

        public bool Lock { get; set; }

        public virtual AddressEntity? Address { get; set; }

        public virtual CivilityEntity? Civility { get; set; }
    }
}
