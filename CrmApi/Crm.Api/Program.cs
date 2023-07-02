using Crm.Api.Infrastructure;
using Crm.Api.Infrastructure.Authentication;
using Crm.Api.Infrastructure.Configuration;
using Crm.Api.Infrastructure.MediatR;
using Crm.Api.Infrastructure.Services;
using Crm.Api.Services;
using Crm.Api.Services.Implementation;
using Crm.API.Common.SwashBuckle;
using FluentValidation;
using IDSoft.CrmWelcome.Api.Infrastructure.AutoMapper;
using IDSoft.CrmWelcome.Domain.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services
               .AddHttpContextAccessor()
               .AddMemoryCache()
               .AddAutoMapper(typeof(AutoMapperProfile));

// Add services to the container.
var appConfiguration = builder.Configuration.Get<AppConfiguration>();
if (appConfiguration != null)
{
    builder.Services.AddSingleton<IAppConfiguration>(appConfiguration);
}
var connectionString = builder.Configuration.GetConnectionString("CrmApi");
if (connectionString != null)
{
    builder.Services.AddSingleton<IConnectionFactory>(new DbConnectionFactory(connectionString));
    builder.Services.AddDbContext<CrmDbContext>(opt => opt.UseSqlServer(connectionString));
}

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var domainAssembly = typeof(CommandHandlerBase<>).GetTypeInfo().Assembly;
builder.Services.AddMediatR(domainAssembly);
builder.Services.AddValidatorsFromAssembly(domainAssembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Crm API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<AttachOperationNameFilter>();

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "apiKey",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
            new List<string>()
        }
                });
});

SecurityKey? signingKey = null;

if (!string.IsNullOrEmpty(appConfiguration?.AuthentificationSettings?.SecretKey))
{
    string key = appConfiguration.AuthentificationSettings.SecretKey;
    signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));


    var tokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = appConfiguration?.JwtOptions?.Issuer,

        ValidateAudience = true,
        ValidAudience = appConfiguration?.JwtOptions?.Audience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,

        RequireExpirationTime = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };


    // https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/issues/415
    // Pour que le "sub" ne soit pas interprété en "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(options =>
        {
            options.ClaimsIssuer = appConfiguration?.JwtOptions?.Issuer;
            options.TokenValidationParameters = tokenValidationParameters;
            options.SaveToken = true;

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() != typeof(SecurityTokenExpiredException))
                        return Task.CompletedTask;

                    context.Response.Headers.Add("Token-Expired", "true");
                    var refererHeader = context.Request.GetTypedHeaders().Referer;
                    if (refererHeader == null)
                        return Task.CompletedTask;
                    var origin = refererHeader.GetComponents(UriComponents.Scheme | UriComponents.Host | UriComponents.Port, UriFormat.UriEscaped);
                    context.Response.Headers.Add("Access-Control-Allow-Origin", origin);

                    return Task.CompletedTask;
                }
            };
        });
}

builder.Services.AddScoped<ICrmService, CrmService>();
builder.Services.AddScoped<ILocalisationService, LocalisationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IVerifieurReferencesService, VerifieurReferencesService>();

var withOrigin = builder.Configuration.GetSection("CORS:AllowedOrigins").Get<string[]>();
builder.Services.AddCors(o => o.AddPolicy("RestrictOrigin", builder =>
{
    builder.WithOrigins(withOrigin)
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithExposedHeaders("Location");
}));

var app = builder.Build();

app.UseCors("RestrictOrigin");

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CrmDbContext>();
    db.Database.Migrate();
}

app.Run();
