using Angular_link_to_DB_API.Common;

namespace Angular_link_to_DB_API.Helpers
{
    partial class Utils
    {
        public IEnumerable<dynamic> GetAuditTrails()
        {
            return _dBHelper.Query(Constants.StoredProcedureGetAuditTrails, new { });
        }
    }
}
