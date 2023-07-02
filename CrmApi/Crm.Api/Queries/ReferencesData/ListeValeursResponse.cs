using Crm.Api.Domain.Abstractions.Queries;
using Crm.Api.ViewModels.DonneeReference;

namespace Crm.Api.Queries.DonneesReference
{
    public class ListeValeursResponse : IResponse<IReadOnlyCollection<ValeurViewModel>>
    {
        public int Total { get; set; }
        public IReadOnlyCollection<ValeurViewModel> Contenu { get; set; } = new List<ValeurViewModel>();
    }
}
