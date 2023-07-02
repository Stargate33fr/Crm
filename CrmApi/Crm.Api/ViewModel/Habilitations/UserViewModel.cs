using IDSoft.TopInvestV6.Domain.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Crm.Api.ViewModels.Habilitations
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public int? CivilityId { get; set; }

        public int? AddressId { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? MobilePhoneNumber { get; set; }

        public string? Mail { get; set; }

        public string? Password { get; set; }

        public bool Actif { get; set; }

        public bool Lock { get; set; }

        public AddressViewModel? Address { get; set; }
    }
}
