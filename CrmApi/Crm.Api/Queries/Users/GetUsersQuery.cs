using Crm.Api.ViewModels.Habilitations;
using MediatR;

namespace Crm.Api.Queries.Users
{
    public class GetUsersQuery: IRequest<UsersResponse?>
    {
    }
}
