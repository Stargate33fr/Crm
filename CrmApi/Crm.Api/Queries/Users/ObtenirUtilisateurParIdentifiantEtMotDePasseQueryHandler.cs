using AutoMapper;
using Crm.Api.Infrastructure.MediatR;
using Crm.Api.Services;
using Crm.Api.ViewModels.Habilitations;

namespace Crm.Api.Queries.Users
{
    public class ObtenirUtilisateurParIdentifiantEtMotDePasseQueryHandler : QueryHandlerBase<ObtenirUtilisateurParIdentifiantEtMotDePasseQuery, UtilisateurResponse?>
    {
        private readonly ICrmService _crmService;

        public ObtenirUtilisateurParIdentifiantEtMotDePasseQueryHandler(ICrmService crmService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(mapper, httpContextAccessor)
        {
            _crmService = crmService ?? throw new ArgumentNullException(nameof(crmService));
        }

        public override async Task<UtilisateurResponse?> Handle(ObtenirUtilisateurParIdentifiantEtMotDePasseQuery request, CancellationToken cancellationToken)
        {
            if (request.Mail !=null && request.Password != null)
            {
                var utilisateurGlobal = await _crmService.ObtientParIdentifiantEtMotDePasseAsync(request.Mail, request.Password, cancellationToken);

                if (utilisateurGlobal == null)
                {
                    // TODO : vérifier le nombre de tentatives erronées, et s'il s'agit bien d'un utilisateur qui existe, si le nombre max d'erreurs est atteint, on le verrouille
                    // var ug = _utilisateurGlobalNHibernateRepository.ObtientParIdentifiant(login.Username);
                }

                return new UtilisateurResponse
                {
                    Contenu = Mapper.Map<UserViewModel>(utilisateurGlobal)
                };
            }
            return null;
        }
    }
}
