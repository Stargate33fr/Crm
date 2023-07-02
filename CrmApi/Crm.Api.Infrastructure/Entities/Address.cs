using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Infrastructure.Entities
{
    public partial class AddressEntity : TrackedEntity
    {
        public AddressEntity()
        {

        }

        public AddressEntity(string street, string complementStreet, int? cityId)
        {
            Street = street;
            ComplementStreet = complementStreet;
            CityId = cityId;
        }

        public int Id { get; set; }

        public int? CityId { get; set; }

        [StringLength(255)]
        public string? Street { get; set; }

        [StringLength(255)]
        public string? ComplementStreet { get; set; }

        public virtual CityEntity? City { get; set; }
    }
}
