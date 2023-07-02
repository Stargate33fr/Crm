using AutoMapper;
using Crm.Api.Domain.Search;
using Crm.Api.Infrastructure.MediatR;
using Crm.Api.Queries.Contacts;
using Crm.Api.Queries.Recherche;
using Crm.Api.Services;
using Crm.Api.ViewModel.Contacts;
using Pagination = Crm.Api.Queries.Recherche.Pagination;

namespace Crm.Api.Queries.Utilisateurs
{
    public class GetContactDetailQueryHandler : QueryHandlerBase<GetContactDetailQuery, ListeContactsResponse?>
    {
        private readonly ICrmService _crmService;
        private readonly IMapper _mapper;
        public GetContactDetailQueryHandler(ICrmService crmService, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _crmService = crmService ?? throw new ArgumentNullException(nameof(crmService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<ListeContactsResponse?> Handle(GetContactDetailQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _crmService.GetContacts(request.Mail, request.FirstName, request.LastName, request.ConseillerId 
                , _mapper.Map<Crm.Api.Domain.Search.Pagination>(request.Pagination), _mapper.Map<Crm.Api.Domain.Search.Tri>(request.Tri),  cancellationToken);

            if (contacts != null)
            {
                return new ListeContactsResponse
                {
                    Total = await _crmService.GetContactsNumber(request.Mail, request.FirstName, request.LastName, request.ConseillerId, cancellationToken),
                    Contenu = Mapper.Map<List<ContactViewModel>>(contacts)
                };
            }
            else
            {
                return new ListeContactsResponse
                {
                    Total = 0,
                    Contenu = new List<ContactViewModel>()
                };
            }
        }
    }
}
