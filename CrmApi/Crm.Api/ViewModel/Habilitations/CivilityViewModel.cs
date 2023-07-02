using System.ComponentModel.DataAnnotations;

namespace Crm.Api.ViewModel.Habilitations
{
    public class CivilityViewModel
    {
        public int Id { get; set; }

        public string ShortName { get; set; } = string.Empty;

        public string LongName { get; set; } = string.Empty;
    }
}
