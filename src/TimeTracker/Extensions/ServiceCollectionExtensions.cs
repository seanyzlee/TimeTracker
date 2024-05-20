using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TimeTracker.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            IConfiguration configuration2 = configuration;
            services.AddAuthentication("Bearer").AddJwtBearer(delegate (JwtBearerOptions options)
            {
                TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration2["Tokens:Issuer"],
                    ValidAudience = configuration2["Tokens:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration2["Tokens:Key"]))
                };
                options.TokenValidationParameters = tokenValidationParameters;
            });
        }
    }
}
