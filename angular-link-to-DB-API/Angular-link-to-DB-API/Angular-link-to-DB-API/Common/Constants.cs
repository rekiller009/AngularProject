namespace Angular_link_to_DB_API.Common
{
    public class Constants
    {
        public enum Status
        {
            OK = 0,
            FAIL = 1
        }

        public enum FilingMDDateType
        {
            EntryIntoForce = 1,
            Signature = 2
        }

        public enum ExtractTextMethod
        {
            ITextSharp = 1,
            Syncfusion = 2
        }

        public const string LoggerName = "Angular_link_to_DB_API";
        public const string DateFormat = "yyyy-MM-dd";
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
        public const string SingaporeCountryCodeId = "6B1ECD5D-7184-4CC5-9A30-77D53204CB3E";
        public const string currentAdminId = "B706422F-4A73-406B-B6BA-4A318370944F";
        //user
        public const string StoredProcedureGetUsers = "prGetUsers";

        //audit trails
        public const string StoredProcedureGetAuditTrails = "prGetAuditTrails";
    }
}
