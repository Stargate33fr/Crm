using Crm.Api.ViewModels.Habilitations;
using MediatR;

namespace Crm.Api.Queries.Users
{
    public class GetUserDetailQuery: IRequest<UtilisateurResponse?>
    {
        public string? Mail { get; set; }
    }
}
