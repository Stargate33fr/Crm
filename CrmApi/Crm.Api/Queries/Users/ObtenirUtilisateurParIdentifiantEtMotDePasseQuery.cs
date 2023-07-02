using MediatR;

namespace Crm.Api.Queries.Users
{
    public class ObtenirUtilisateurParIdentifiantEtMotDePasseQuery : IRequest<UtilisateurResponse?>
    {
        public string? Mail { get; set; }
        public string? Password { get; set; }
    }
}
