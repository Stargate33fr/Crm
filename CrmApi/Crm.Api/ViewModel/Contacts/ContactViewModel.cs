using IDSoft.TopInvestV6.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Crm.Api.ViewModel.Contacts
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Mail { get; set; }

        public string? PhoneNumber { get; set; }

        public string? MobilePhoneNumber { get; set; }

        public AddressViewModel? Address { get; set; }

        public int ConseillerId { get; set; }

        public string? FirstNameConseiller { get; set; }

        public string? LastNameConseiller { get; set; }
    }
}
