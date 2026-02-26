namespace FinCRM.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
<<<<<<< HEAD:FinCRM/Domain/User.cs
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public bool IsActive { get; set; }
=======
        public int  RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public bool  IsActive { get; set; }
>>>>>>> origin/main:FinCRM/Models/User.cs
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

    }
}
