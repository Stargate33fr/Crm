using Crm.Api.Queries.Contacts;
using Crm.Api.Queries.Recherche;
using MediatR;

namespace Crm.Api.Queries.Utilisateurs
{
    public class GetContactDetailQuery : IRequest<ListeContactsResponse?>
    {
        public string? Mail { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? ConseillerId { get; set; }

        public Pagination? Pagination { get; set; }

        public Tri? Tri { get; set; }
    }
}
