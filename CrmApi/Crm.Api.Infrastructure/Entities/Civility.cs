using Crm.Api.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Infrastructure.Entities
{
    public partial class CivilityEntity : TrackedEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string ShortName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LongName { get; set; } = string.Empty;
    }
}
