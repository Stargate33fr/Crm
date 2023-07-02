using AutoMapper;
using Crm.Api.Infrastructure.MediatR;
using Crm.Api.Services;
using Crm.Api.ViewModel.Habilitations;
using Crm.Api.ViewModels.Habilitations;

namespace Crm.Api.Queries.Users
{
    public class GetUsersQueryHandler : QueryHandlerBase<GetUsersQuery, UsersResponse?>
    {
        private readonly ICrmService _crmService;
        public GetUsersQueryHandler(ICrmService crmService, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _crmService = crmService ?? throw new ArgumentNullException(nameof(crmService));
        }

        public override async Task<UsersResponse?> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _crmService.GetUsersAsync(cancellationToken);

            if (users == null)
            {
            }

            return new UsersResponse
            {
                Contenu = Mapper.Map<List<UserSimplifieeViewModel>>(users)
            };
        }
    }
}
