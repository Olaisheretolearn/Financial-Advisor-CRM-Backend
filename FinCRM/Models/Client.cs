namespace FinCRM.Models
{
    public class Client
    {
        public int Id { get; set; } 
        public int AdvisorId { get; set; }
        public User Advisor { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string PhoneNumber   { get; set; } = null!;
        public string RiskTolerance { get; set; } = null!;
        public bool KycCompleted { get; set; }
        public bool IsActive {  get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get;set; }
        public int Version { get; set; }
    }
}
