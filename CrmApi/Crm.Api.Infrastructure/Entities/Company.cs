using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Api.Infrastructure.Entities
{
    public class CompanyEntity : TrackedEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public int? AddressId { get; set; }
        public string? Mail { get; set; }
        [StringLength(255)]
        public string? PhoneNumber { get; set; }
        [StringLength(255)]
        public string? MobilePhoneNumber { get; set; }
        public virtual AddressEntity? Address { get; set; }
    }
}
