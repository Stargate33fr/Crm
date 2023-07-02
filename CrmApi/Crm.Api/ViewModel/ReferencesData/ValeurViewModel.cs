namespace Crm.Api.ViewModels.DonneeReference
{
    public class ValeurViewModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Libelle { get; set; }
        public List<ValeurViewModel> SousListe { get; set; } = new List<ValeurViewModel>();
        public bool? EstVisible { get; set; }
        public string? ValeurAssociee { get; set; }
    }
}
