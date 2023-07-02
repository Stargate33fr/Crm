using Crm.Api.Domain.Authentification;
using Crm.Api.Infrastructure.Configuration;
using Crm.Api.ViewModels.Habilitations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Crm.Api.Infrastructure.Authentication
{
    public class TokenService : ITokenService
    {
        private readonly AuthentificationSettings _authentificationSettings;
        private readonly JwtOptions _jwtOptions;
        private readonly byte[]? _secretJwt;

        public TokenService(IAppConfiguration appConfiguration)
        {
            _authentificationSettings = appConfiguration.AuthentificationSettings;
            _secretJwt = null;
            _jwtOptions = appConfiguration.JwtOptions;
            if (appConfiguration.AuthentificationSettings.SecretKey != null)
            {
                _secretJwt = Encoding.UTF8.GetBytes(appConfiguration.AuthentificationSettings.SecretKey);
            }
        }

        public string? GetAccessToken(UserViewModel? utilisateur)
        {
            if (utilisateur != null 
                && utilisateur.Mail !=null
                 && utilisateur.FirstName != null
                  && utilisateur.Password != null
                   && utilisateur.LastName != null

                )
            {
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, utilisateur.Mail),
                new Claim(CrmClaimTypes.UserId, utilisateur.Id.ToString()),
                new Claim(CrmClaimTypes.FirstName, utilisateur.FirstName),
                new Claim(CrmClaimTypes.Password, utilisateur.Password),
                new Claim(CrmClaimTypes.LastName, utilisateur.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var clé = new SymmetricSecurityKey(_secretJwt);
                var creds = new SigningCredentials(clé, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_jwtOptions.Issuer,
                    _jwtOptions.Audience,
                    claims,
                    expires: DateTime.Now.AddSeconds(_authentificationSettings.DureeValiditeAccessToken),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return null;
            }
         
        }

        public string? GetRefreshToken(string? login)
        {
            if (login != null)
            {
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 };

                var clé = new SymmetricSecurityKey(_secretJwt);
                var creds = new SigningCredentials(clé, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_jwtOptions.Issuer,
                    _jwtOptions.Audience,
                    claims,
                    expires: DateTime.Now.AddSeconds(_authentificationSettings.DureeValiditeRefreshToken),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            else
            {
                return null;
            }
        }
    }
}
