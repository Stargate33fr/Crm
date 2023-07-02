using Crm.Api.ViewModels.Habilitations;

namespace Crm.Api.Infrastructure.Authentication
{
    public interface ITokenService
    {
        string? GetAccessToken(UserViewModel? utilisateur);
        string? GetRefreshToken(string? login);
    }
}
