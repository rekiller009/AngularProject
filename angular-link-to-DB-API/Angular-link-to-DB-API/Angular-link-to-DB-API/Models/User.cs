namespace Angular_link_to_DB_API.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public DateTime LastActivityDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
