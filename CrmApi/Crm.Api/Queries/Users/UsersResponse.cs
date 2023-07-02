using Crm.Api.Domain.Abstractions.Queries;
using Crm.Api.ViewModel.Habilitations;
using Crm.Api.ViewModels.Habilitations;

namespace Crm.Api.Queries.Users
{
    public class UsersResponse : IResponse<List<UserSimplifieeViewModel>?>
    {
        public List<UserSimplifieeViewModel>? Contenu { get; set; }
    }
}