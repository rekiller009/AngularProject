
namespace Angular_link_to_DB_API.Helpers
{
    public partial class Utils
    {
        private readonly ILogger<Utils> _logger;
        private readonly DBHelper _dBHelper;
        private readonly IConfiguration _configuration;

        public Utils(ILogger<Utils> logger, DBHelper dBHelper, IConfiguration configuration)
        {
            _logger = logger;
            _dBHelper = dBHelper;
            _configuration = configuration;
        }

    }
}
