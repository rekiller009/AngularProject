using Angular_link_to_DB_API.Authentication;
using Microsoft.Extensions.Options;

namespace Angular_link_to_DB_API.OptionSetup
{
    public class OptionSetup : IConfigureOptions<TokenOption>
    {
        private readonly IConfiguration _configuration;
        private const string SectionName = "Jwt";
        public OptionSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(TokenOption options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }

    }
}
