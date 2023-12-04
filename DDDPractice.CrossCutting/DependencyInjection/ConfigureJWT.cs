using DDDPractice.Domain.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace DDDPractice.CrossCutting.DependencyInjection
{
    public static class ConfigureJWT
    {
        public static IServiceCollection ConfigureDependenciesJWT(this IServiceCollection services, IConfiguration configuration)
        {
            //Token
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);
            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);
            services.AddAuthentication(authOptions => {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = tokenConfigurations.Issuer,
                    ValidAudience = tokenConfigurations.Audience,
                    IssuerSigningKey = signingConfigurations.Key,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddAuthorization(auth => {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
            return services;
        }
        
    }
}