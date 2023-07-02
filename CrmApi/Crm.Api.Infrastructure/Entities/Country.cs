using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Infrastructure.Entities
{
    public partial class CountryEntity : TrackedEntity
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string SearchName { get; set; } = string.Empty;

        public virtual ICollection<RegionEntity> Regions { get; set; } = new List<RegionEntity>();
    }
}
