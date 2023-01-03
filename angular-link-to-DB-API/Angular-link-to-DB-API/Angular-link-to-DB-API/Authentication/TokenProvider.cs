using Angular_link_to_DB_API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Angular_link_to_DB_API.Authentication
{

   
    internal sealed class TokenProvider : IJwtProvider
    {

        private readonly TokenOption _options;
        public TokenProvider(IOptions<TokenOption> options)
        {
            _options = options.Value;
        }
        public string Generate(User user)
        {
            var claims = new Claim[] { 
                new Claim(JwtRegisteredClaimNames.Sub,User.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,User.Email)
            };

            var siginingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                null,
                null,
                DateTime.UtcNow.AddHours(1),
                null);

            string tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return tokenValue;
        }
    }

    internal interface IJwtProvider
    {
    }

}
