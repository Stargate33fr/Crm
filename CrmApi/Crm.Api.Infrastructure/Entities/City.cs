using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Infrastructure.Entities
{
    public partial class CityEntity : TrackedEntity
    {
        public int Id { get; set; }

        public int? DepartementId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string InseeCode { get; set; } = string.Empty;

        [StringLength(255)]
        public string? SearchName { get; set; }

        public virtual DepartmentEntity? Department { get; set; }
    }
}
