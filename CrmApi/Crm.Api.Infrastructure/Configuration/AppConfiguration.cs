namespace Crm.Api.Infrastructure.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public AuthentificationSettings? AuthentificationSettings { get; set; }
        public JwtOptions? JwtOptions { get; set; }
    }
}
