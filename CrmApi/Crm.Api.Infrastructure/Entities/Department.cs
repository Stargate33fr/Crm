using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Infrastructure.Entities
{
    public partial class DepartmentEntity : TrackedEntity
    {
        public int Id { get; set; }

        public int? RegionId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(3)]
        public string Code { get; set; } = string.Empty;

        [StringLength(255)]
        public string SearchName { get; set; } = string.Empty;

        public virtual RegionEntity? Region { get; set; }

        public virtual ICollection<CityEntity> Villes { get; set; } = new HashSet<CityEntity>();
    }
}
