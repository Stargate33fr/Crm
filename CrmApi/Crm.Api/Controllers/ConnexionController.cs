using Crm.Api.Infrastruture.Helpers;
using Crm.Api.Queries.Users;
using Crm.Api.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text;
using Crm.Api.Commands.Connexions;
using Crm.Api.Infrastructure.Helpers;

namespace Crm.Api.Controllers
{
    /// <summary>
    /// User
    /// </summary>
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ConnexionController : AppControllerBase
    {
        private readonly ITokenService _tokenservice;
        private readonly ILogger<ConnexionController> _logger;
        public ConnexionController(ITokenService tokenService, ILogger<ConnexionController> logger, IMediator mediator)
              : base(mediator)
        {
            _tokenservice = tokenService;
            _logger = logger;
        }


        [HttpPost("login"), AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> LoginAsync(CancellationToken cancellationToken)
        {
            if (!AuthenticationHeaderValue.TryParse(Request.Headers[HeaderNames.Authorization], out var authHeader) || authHeader.Scheme != "Basic" || string.IsNullOrEmpty(authHeader.Parameter))
                return Unauthorized();

            try
            {
                var userNameAndPassword = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                var userName = userNameAndPassword[0];
                var password = userNameAndPassword[1];
                var response = await Mediator.Send(new ObtenirUtilisateurParIdentifiantEtMotDePasseQuery
                {
                    Mail = userName,
                    Password = password
                }, cancellationToken);
                if (response == null || (response != null && response.Contenu !=null && (!response.Contenu.Actif || response.Contenu.Lock)))
                    return Unauthorized();

                if (response != null && response.Contenu != null)
                {
                    response.Contenu.Password = Encryption.Encrypt(password);

                    AjouteCookieRefreshToken(response.Contenu.Mail);
                }
                else
                {
                    return Unauthorized();
                }
                  

                return Ok(new { accessToken = _tokenservice.GetAccessToken(response.Contenu) });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Erreur");
                return Unauthorized();
            }
        }

        [HttpPut("changepasswordconnected")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ChangePasswordConnectedAsync(CancellationToken cancellationToken)
        {
            AuthenticationHeaderValue.TryParse(Request.Headers[HeaderNames.Authorization], out var authHeader);
            if (!AuthenticationHeaderValue.TryParse(Request.Headers[HeaderNames.Authorization], out authHeader) || authHeader.Scheme != "Bearer" || string.IsNullOrEmpty(authHeader.Parameter))
                return Unauthorized();

            try
            {
                var authHeaderInformation = Request.Headers[HeaderNames.ContentEncoding].FirstOrDefault();
                if (!string.IsNullOrEmpty(authHeaderInformation))
                {
                    var userNameAndPassword = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderInformation)).Split(':');
                    var userName = userNameAndPassword[0];
                    var password = userNameAndPassword[1];
                    var ancienPassword = userNameAndPassword[2];
                    var token = userNameAndPassword[3];

                    var response = await Mediator.Send(new ObtenirUtilisateurParIdentifiantEtMotDePasseQuery
                    {
                        Mail = userName,
                        Password = ancienPassword
                    }, cancellationToken);
                    if (response?.Contenu == null)
                        return Unauthorized();

                    var reponse = await Mediator.Send(new UpdatePasswordCommand
                    {
                        Login = userName,
                        Password = password
                    }, cancellationToken);

                    return Ok(true);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Erreur");
                return Unauthorized();
            }
        }

        private void AjouteCookieRefreshToken(string? login)
        {
            if (login != null)
            {
                Response.Cookies.Append("refreshToken", _tokenservice.GetRefreshToken(login), new CookieOptions()
                {
                    Domain = Request.Host.Host,
                    Path = "/",
                    HttpOnly = true,
                    //Secure = true
                });
            } 
        }
    }
}
