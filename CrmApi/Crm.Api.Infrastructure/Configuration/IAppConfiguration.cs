namespace Crm.Api.Infrastructure.Configuration
{
    public interface IAppConfiguration
    {
        AuthentificationSettings AuthentificationSettings { get; set; }
        JwtOptions JwtOptions { get; set; }
    }
}
