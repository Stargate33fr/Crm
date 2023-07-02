namespace Crm.Api.Infrastructure.Configuration
{
    public class JwtOptions
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Authority { get; set; }
    }
}
