namespace Angular_link_to_DB_API.Models
{
    public class User
    {
        public static Guid UserId { get; set; }
        public static string LoginId { get; set; }
        public static string UserName { get; set; }
        public static string Email { get; set; }
        public static DateTime LastActivityDate { get; set; }
        public static Guid CreatedBy { get; set; }
        public static DateTime CreatedDate { get; set; }
        public static Guid UpdateBy { get; set; }
        public static DateTime UpdatedDate { get; set; }
        public static Guid DeletedBy { get; set; }
        public static DateTime DeletedDate { get; set; }

        public ContractStatus Status { get; set; }
    }

    public enum ContractStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
