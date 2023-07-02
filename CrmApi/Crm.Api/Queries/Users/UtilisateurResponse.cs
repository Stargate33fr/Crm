using Crm.Api.Domain.Abstractions.Queries;
using Crm.Api.ViewModels.Habilitations;

namespace Crm.Api.Queries.Users
{
    public class UtilisateurResponse : IResponse<UserViewModel?>
    {
        public UserViewModel? Contenu { get; set; } 
    }
}