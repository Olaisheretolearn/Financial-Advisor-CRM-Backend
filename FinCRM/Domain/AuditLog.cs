namespace FinCRM.Domain
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string EntityName { get; set; } = null!;
        public int EntityId { get; set; }
        public AuditAction Action { get; set; }


        public int ChangedBy { get; set; }
        public User changedBy { get; set; } = null!;


        public string? OldValues { get; set; }
        public string? NewValues { get; set; }

        public DateTimeOffset Timestamp { get; set; }


    }

    public enum AuditAction
    {
        Created,
        Updated,
        Deleted,
    }
}
