using Crm.Api.Domain.Abstractions.Queries;
using Crm.Api.ViewModel.Contacts;

namespace Crm.Api.Queries.Contacts
{
    public class ListeContactsResponse : IResponse<IReadOnlyCollection<ContactViewModel>>
    {
        public int Total { get; set; }
        public IReadOnlyCollection<ContactViewModel> Contenu { get; set; } = new List<ContactViewModel>();
    }
}
