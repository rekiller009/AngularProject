using Angular_link_to_DB_API.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Angular_link_to_DB_API.OptionSetup
{
    public class BearerOptionSetup : IConfigureOptions<JwtBearerOptions>
    {
        private readonly TokenOption _options;

        public BearerOptionSetup(IOptions<TokenOption> options)
        {
            _options = options.Value;
        }

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _options.Issuer,
                ValidAudience = _options.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SecretKey))
            };
        }
    }
}
