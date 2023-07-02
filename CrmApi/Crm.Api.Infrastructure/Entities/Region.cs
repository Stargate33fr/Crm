using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Infrastructure.Entities
{
    public partial class RegionEntity : TrackedEntity
    {
        public int Id { get; set; }

        public int? CountryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(3)]
        public string Code { get; set; } = string.Empty;

        [StringLength(255)]
        public string SearchName { get; set; } = string.Empty;

        public virtual CountryEntity? Country { get; set; }

        public virtual ICollection<DepartmentEntity> Departments { get; set; } = new List<DepartmentEntity>();
    }
}
