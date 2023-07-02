namespace Crm.Api.Infrastructure.Configuration
{
    public class AuthentificationSettings
    {
        public int DureeValiditeAccessToken { get; set; }
        public int DureeValiditeRefreshToken { get; set; }
        public string? SecretKey { get; set; }
        public string? PasseSecret { get; set; }
    }
}
